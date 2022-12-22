using lab7.Shared;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;

namespace lab7.Client.Services
{
    public class BookServices : IBookServices
    {
        private readonly HttpClient _httpClient;
        public BookServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<Book> books { get; set; } = new List<Book>();

        public async Task GetBooks()
        {
            books = await _httpClient.GetFromJsonAsync<List<Book>>("api/Book");
        }

        public async Task<Book> GetBook(int id)
        {
            return await _httpClient.GetFromJsonAsync<Book>("api/Book/{id}");
        }

        public async Task Create(Book book)
        {
            await _httpClient.PostAsJsonAsync<Book>("api/Book/", book);
        }

        public async Task Edit(Book book, int id)
        {
            await _httpClient.PutAsJsonAsync<Book>($"api/Book/{id}", book);
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync($"api/Book/{id}");
        }
    }
}
