namespace lab6.Data
{
    public interface IBookServices
    {
        List<Book> books { get; set; }
        Task GetBooks();
        Task<Book> GetBook(int id);
        Task Create(Book book);
        Task Edit(Book book, int id);
        Task Delete(int id);
    }
}
