using System.Reflection.Metadata;
using System.Text;
using System.Xml.Schema;
using Boardgames.Data.Models;
using Boardgames.Data.Models.Enums;
using Boardgames.DataProcessor.ImportDto;
using Boardgames.Utilities;
using Newtonsoft.Json;

namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using Boardgames.Data;
   
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            XmlHelper helper = new XmlHelper();
            const string xmlRoot = "Creators";

            ImportCreatorsDto[] deserializedCreators =
                helper.Deseriaize<ImportCreatorsDto[]>(xmlString, xmlRoot);

            ICollection<Creator> creatorsToImport = new List<Creator>();
            var sb = new StringBuilder();
            foreach (var creatordto in deserializedCreators)
            {
                if (!IsValid(creatordto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Creator creator = new Creator()
                {
                    FirstName = creatordto.FirstName,
                    LastName = creatordto.LastName
                };

                foreach (var boardgamedto in creatordto.Boardgames)
                {
                    if (!IsValid(boardgamedto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Boardgame boardgame = new Boardgame()
                    {
                        Name = boardgamedto.Name,
                        Rating = boardgamedto.Rating,
                        YearPublished = boardgamedto.YearPublished,
                        CategoryType = (CategoryType)boardgamedto.CategoryType,
                        Mechanics = boardgamedto.Mechanics
                    };
                    creator.Boardgames.Add(boardgame);
                }
                creatorsToImport.Add(creator);
                sb.AppendLine
                (string.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName,
                    creator.Boardgames.Count));
            }

            context.Creators.AddRange(creatorsToImport);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            ImportSellersDto[] jsontext = JsonConvert.DeserializeObject<ImportSellersDto[]>(jsonString);
            
            ICollection<Seller> sellers = new List<Seller>();

            var sb = new StringBuilder();
            foreach (var sellerDto in jsontext)
            {
                if (!IsValid(sellerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Seller seller = new Seller()
                {
                    Name = sellerDto.Name,
                    Address = sellerDto.Address,
                    Country = sellerDto.Country,
                    Website = sellerDto.Website,
                };
                foreach (var gameId in sellerDto.Boardgames.Distinct())
                {
                    var gamesIds = context.Boardgames.Select(x => x.Id).ToArray();

                    if(!gamesIds.Contains(gameId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    BoardgameSeller boardgameSeller = new BoardgameSeller()
                    {
                        SellerId = seller.Id,
                        BoardgameId = gameId
                    };
                    seller.BoardgamesSellers.Add(boardgameSeller);
                }

                sb.AppendLine(string.Format(SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count));
                sellers.Add(seller);
            }
            context.Sellers.AddRange(sellers);
            context.SaveChanges();


            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
