using ClassLibrary.Helper;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace ClassLibrary.Extensions
{
    public static class HttpExtension
    {

        public static void AddPaginationHeader(
            this HttpResponse response,
            int currentPage,
            int itemsPerPage,
            int totalItems,
            int totalPage,
            bool hasPreviousPage,
            bool hasNextPage)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var paginationheader = new PaginationHeader(currentPage, itemsPerPage, totalItems, totalPage, hasPreviousPage, hasNextPage);
            response.Headers.Add("Pagination", JsonSerializer.Serialize(paginationheader, options));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");

        }
    }
}
