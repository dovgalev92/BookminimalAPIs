using BookMinAPIs.Data.Interface;
using BookMinAPIs.Models.Entity;
using BookMinAPIs.DTO;
using Microsoft.EntityFrameworkCore;

namespace BookMinAPIs.Data
{
    public class ActionDbContext : IActionDbContext<Book, Author>,ICommandRead_Id<Book>, ICommandRead<Book>
    {
        private readonly ApplicationDbContext _context;
        public ActionDbContext(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task CommandCreateAuthor(Author author)
        {
            if(author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }
            _context.Entry(author).State = EntityState.Added;
            await SaveChangesAsync();
        }
        public async Task CommandBookCreate(int id, Book bookCrt)
        {

            if(bookCrt == null && id == 0)
            {
                throw new ArgumentNullException(nameof(bookCrt), "Ошибка. Нет данных");
            }
            bookCrt!.Authors = _context.Authors!.Where(x => x.AuthorId == id).FirstOrDefault();

            await _context.AddAsync(bookCrt);
            await SaveChangesAsync();

        }
        public async Task<IEnumerable<Book>> CommandAllBookRead()
        {
            return await _context.Books!.Include(a => a.Authors).ToListAsync();
        }

        public async Task CommandDeleteBook(int? bookId)
        {
           var book = bookId !=null? _context.Books?.Find(bookId) : throw new  ArgumentNullException(nameof(bookId));
           _context.Entry(book!).State = EntityState.Deleted;
           await SaveChangesAsync();
        }

        public Book CommandReadById(int? bookId)
        {
            if(bookId == null)
            {
                throw new ArgumentNullException(nameof(bookId));
            }    
            var book = _context.Books!.Where(x => x.BookId == bookId).FirstOrDefault();

            return book!;
        }

        public Task CommandUpdate(Book bookUpt)
        {
            if(bookUpt == null)
            {
                throw new ArgumentNullException(nameof(bookUpt));
            }
            _context.Entry(bookUpt).State = EntityState.Modified;
            return SaveChangesAsync(); 

        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}