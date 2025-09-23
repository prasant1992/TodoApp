using ToDo.Domain.Entity;
using ToDo.InMemory.Db.Repository;

namespace ToDo.Tests
{
    public class ToDoItemRepositoryTests
    {
        [Test]
        public void Add_ShallReturnNewItemId_WhenCreatingNewEntity()
        {
            ToDoItem input = new ToDoItem
            {
                Title = "Test Item",
                Description = "This is a test item"
            };

            var repository = new ToDoItemRepository();
            var result = repository.Add(input).Result;
            Assert.That(result.Id, Is.GreaterThan(0));
        }

        [Test]
        public void Add_ShallReturnNull_WhenCreatingUsingExistingEntity()
        {
            ToDoItem item1 = new ToDoItem
            {
                Id = 1,
                Title = "Test Item",
                Description = "This is a test item"
            };

            ToDoItem item2 = new ToDoItem
            {
                Id = 1,
                Title = "Test Item",
                Description = "This is a test item"
            };

            var repository = new ToDoItemRepository();
            var result = repository.Add(item1).Result;
            var result2 = repository.Add(item2).Result;
            Assert.That(result2, Is.Null);
        }

        [Test]
        public void Delete_ShallReturnOne_WhenDeletingExistingEntity()
        {
            ToDoItem item1 = new ToDoItem
            {
                Title = "Test Item",
                Description = "This is a test item"
            };
            var repository = new ToDoItemRepository();
            var result = repository.Add(item1).Result;
            var deleteResult = repository.Delete(result.Id).Result;
            Assert.That(deleteResult, Is.EqualTo(1));
        }

        [Test]
        public void Delete_ShallReturnZero_WhenDeletingNonExistingEntity()
        {
            ToDoItem item1 = new ToDoItem
            {
                Id = 1,
                Title = "Test Item",
                Description = "This is a test item"
            };
            var repository = new ToDoItemRepository();
            var deleteResult = repository.Delete(1).Result;
            Assert.That(deleteResult, Is.EqualTo(0));
        }

        [Test]
        public void GetAll_ShallReturnAllItems_WhenItemsExist()
        {
            ToDoItem item1 = new ToDoItem
            {
                Title = "Test Item 1",
                Description = "This is a test item 1"
            };
            ToDoItem item2 = new ToDoItem
            {
                Title = "Test Item 2",
                Description = "This is a test item 2"
            };
            var repository = new ToDoItemRepository();
            var result1 = repository.Add(item1).Result;
            var result2 = repository.Add(item2).Result;
            var allItems = repository.GetAll().Result;
            Assert.That(allItems.Count(), Is.EqualTo(2));
        }

        [Test]
        public void GetAll_ShallReturnOne_WhenAddingThenRemovingOne()
        {
            ToDoItem item1 = new ToDoItem
            {
                Title = "Test Item 1",
                Description = "This is a test item 1"
            };
            ToDoItem item2 = new ToDoItem
            {
                Title = "Test Item 2",
                Description = "This is a test item 2"
            };
            var repository = new ToDoItemRepository();
            var result1 = repository.Add(item1).Result;
            var result2 = repository.Add(item2).Result;
            var deleteResult = repository.Delete(result1.Id).Result;
            var allItems = repository.GetAll().Result;
            Assert.That(allItems.Count(), Is.EqualTo(1));
        }
    }
}
