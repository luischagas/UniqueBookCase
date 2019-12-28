using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UniqueBookCase.Api;
using UniqueBookCase.Api.ViewModels;
using UniqueBookCase.WebApi.Tests.Config;
using Xunit;

namespace UniqueBookCase.WebApi.Tests
{
    [Collection(nameof(IntegrationApiTestsFixtureCollection))]
    public class AuthorTests
    {
        private readonly IntegrationTestsFixture<Startup> _testsFixture;

        public AuthorTests(IntegrationTestsFixture<Startup> testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Add New Author With Books")]
        [Trait("Category", "Integration API - Author")]
        public async Task AddAuthorWithBooks_MustReturnSuccessfully()
        {

            var books = new List<BookViewModel>();

            books.Add(new BookViewModel()
            {
                Title = "Domain Driven Design",
                ReleaseDate = Convert.ToDateTime("2010-01-01"),
                ISBN = "111-22-333-4444-5",
                Category = "Systems Architecture"
            });

            books.Add(new BookViewModel()
            {
                Title = "Clean Code",
                ReleaseDate = Convert.ToDateTime("2012-02-04"),
                ISBN = "222-33-444-5555-6",
                Category = "Development"
            });

            var author = new AuthorViewModel
            {
                Name = "Luís Felipe",
                DateOfBirth = Convert.ToDateTime("1980-01-08"),
                Document = "111.111.111-11",
                Books = books
        };

            await _testsFixture.LoginApi();
            _testsFixture.Client.AssignToken(_testsFixture.UserToken);

            var postResponse = await _testsFixture.Client.PostAsJsonAsync("api/author", author);


            postResponse.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Add New Author Without Document")]
        [Trait("Category", "Integration API - Author")]
        public async Task AddAuthorWithoutDocument_MustReturnUnsuccessfully()
        {

            var books = new List<BookViewModel>();

            books.Add(new BookViewModel()
            {
                Title = "Domain Driven Design",
                ReleaseDate = Convert.ToDateTime("2010-01-01"),
                ISBN = "111-22-333-4444-5",
                Category = "Systems Architecture"
            });

            books.Add(new BookViewModel()
            {
                Title = "Clean Code",
                ReleaseDate = Convert.ToDateTime("2012-02-04"),
                ISBN = "222-33-444-5555-6",
                Category = "Development"
            });

            var author = new AuthorViewModel
            {
                Name = "Luís Felipe",
                DateOfBirth = Convert.ToDateTime("1980-01-08"),
                Document = "",
                Books = books
            };

            await _testsFixture.LoginApi();
            _testsFixture.Client.AssignToken(_testsFixture.UserToken);

            var postResponse = await _testsFixture.Client.PostAsJsonAsync("api/author", author);


            postResponse.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Update Author")]
        [Trait("Category", "Integration API - Author")]
        public async Task UpdateAuthor_MustReturnSuccessfully()
        {

            var author = new AuthorViewModel
            {
                Id = new Guid("13ced886-11e6-4c20-5d52-08d78b471d03"),
                Name = "Fernando",
                DateOfBirth = Convert.ToDateTime("1985-03-04"),
                Document = "222.222.222-22",
            };

            await _testsFixture.LoginApi();
            _testsFixture.Client.AssignToken(_testsFixture.UserToken);

            var putResponse = await _testsFixture.Client.PutAsJsonAsync($"api/author/{author.Id}", author);

            putResponse.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Delete Author")]
        [Trait("Category", "Integration API - Author")]
        public async Task DeleteAuthor_MustReturnSuccessfully()
        {

            var author = new AuthorViewModel
            {
                Id = new Guid("68be4df8-f769-48ac-0b90-08d78b4a6561")
            };

            await _testsFixture.LoginApi();
            _testsFixture.Client.AssignToken(_testsFixture.UserToken);

            var deleteResponse = await _testsFixture.Client.DeleteAsync($"api/author/{author.Id}");

            deleteResponse.EnsureSuccessStatusCode();
        }

    }
}
