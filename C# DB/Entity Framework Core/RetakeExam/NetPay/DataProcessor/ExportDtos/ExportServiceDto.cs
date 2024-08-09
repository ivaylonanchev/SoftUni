namespace NetPay.DataProcessor.ExportDtos;

public class ExportServiceDto
{
    public string ServiceName { get; set; }
    public List<ExportSuppliers> Suppliers { get; set; }
}