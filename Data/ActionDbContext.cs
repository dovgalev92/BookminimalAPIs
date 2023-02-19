using BookMinAPIs.Data.Interface;
using BookMinAPIs.Models.Entity;
using AutoMapper;
using BookMinAPIs.DTO;
using Microsoft.EntityFrameworkCore;

namespace BookMinAPIs.Data
{
    public class ActionDbContext : IActionDbContext<CreateBookDtos>, ICommandRead<ReadBooksDtos>, ICommandRead_Id<Book, ReadBookDto_Id>, ICommandUpdate<Book>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ActionDbContext(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task CommandBookCreate(CreateBookDtos bookCrt)
        {
            if(bookCrt == null)
            {
                throw new ArgumentNullException(nameof(bookCrt), "отсувствуют входные данные");
            }
            var itemBooks = _mapper.Map<Book>(bookCrt);
            await _context.AddAsync(itemBooks);
            await SaveChangesAsync();

        }
        public async Task<IEnumerable<ReadBooksDtos>> CommandAllBookRead()
        {
            var listBooks =  await _context.Books!.Include(author => author.Author).AsNoTracking().ToListAsync();
            var item = _mapper.Map<IEnumerable<ReadBooksDtos>>(listBooks);
            return item;
        }

        public void CommandDeleteBook(int? bookId)
        {
            throw new NotImplementedException();
        }

        public ReadBookDto_Id CommandReadById(Book bookId)
        {
            throw new NotImplementedException();
        }

        public Task CommandUpdate(Book bookUpt)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}