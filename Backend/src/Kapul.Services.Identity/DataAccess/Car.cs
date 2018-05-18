using System;
using Kapul.Services.Identity.DataAccess.Interfaces;

namespace Kapul.Services.Identity.DataAccess
{
    public class Car : ICar
    {
        private IdentityContext _context;
        private ILogger _logger;
        public TodoItemsDAL(TodoContext context, ILogger<TodoItemsDAL> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<TodoItem> Create(TodoItem item)
        {
            try
            {
                _context.TodoItems.Add(item);
                await _context.SaveChangesAsync();
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error on create Item");
                return null;
            }
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                var todoItem = _context.TodoItems.FirstOrDefault(x => x.Id == id);
                if (todoItem != null)
                {
                    _context.TodoItems.Remove(todoItem);
                    await _context.SaveChangesAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error on delete Item");
            }
            return false;
        }

        public async Task<IEnumerable<TodoItem>> GetAll()
        {
            try
            {
                return await _context.TodoItems.ToListAsync();
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "error on get all Items");
                return null;
            }
        }

        public async Task<TodoItem> GetById(long id)
        {
            try
            {
                return await _context.TodoItems.FirstOrDefaultAsync(x => x.Id == id);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, $"error on get Item with id :{id}");
                return null;
            }
        }

        public async Task<bool> Update(TodoItem item)
        {
            try
            {
                _context.TodoItems.Update(item);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "error on update Item");
                return false;
            }

        }
    }
}
