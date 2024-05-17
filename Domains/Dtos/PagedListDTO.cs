using School.Entity;

public class PagedListDTO<T>
{
    public int total { get; set; }
    public int page { get; set; }
    public int pageSize { get; set; }
    public IEnumerable<T> items { get; set; }
}
