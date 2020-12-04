namespace OptimationTechnicalTest.Models.API
{
    public class ApiResponseModel
    {
        public bool IsRequestSuccessful { get; set; }
        public string ErrorMessage { get; set; }
        public decimal GstCost { get;  set; }
        public decimal TotalExcludingGst { get; set; }
    }
}