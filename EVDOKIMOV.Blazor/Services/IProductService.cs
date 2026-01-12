namespace EVDOKIMOV.Blazor.Services
{
    public interface IProductService<T> where T : class
    {
        event Action ListChanged;

        // список объектов
        IEnumerable<T> Products { get; }
        // номер текущей страницы
        int CurrentPage { get; }
        // общее количество страниц
        int TotalPages { get; }
        // получение списка объектов
        Task GetProducts(int pageNo = 1);
    }
}
