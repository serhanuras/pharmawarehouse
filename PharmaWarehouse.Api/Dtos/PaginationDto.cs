namespace PharmaWarehouse.Api.Dto
{
    public class PaginationDto
    {
        private readonly int maxRecordsPerPage = 100;
        private int recordsPerPage = 100;

        public int Page { get; set; } = 1;

        public int RecordsPerPage
        {
            get
            {
                return this.recordsPerPage;
            }

            set
            {
                this.recordsPerPage = (value > this.maxRecordsPerPage) ? this.maxRecordsPerPage : value;
            }
        }
    }
}
