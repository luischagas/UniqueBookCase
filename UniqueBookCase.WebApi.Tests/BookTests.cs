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
    public class BookTests
    {
        private readonly IntegrationTestsFixture<Startup> _testsFixture;

        public BookTests(IntegrationTestsFixture<Startup> testsFixture)
        {
            _testsFixture = testsFixture;
        }

        [Fact(DisplayName = "Update Book")]
        [Trait("Category", "Integration API - Book")]
        public async Task UpdateBook_MustReturnSuccessfully()
        {

            var book = new BookViewModel
            {
                Id = new Guid("e1466a05-2df0-41e3-81a2-08d78b4a656e"),
                Title = "TDD",
                ReleaseDate = Convert.ToDateTime("2015-02-04"),
                ISBN = "555-66-777-8888-9",
                Category = "Dev"
            };

            await _testsFixture.LoginApi();
            _testsFixture.Client.AssignToken(_testsFixture.UserToken);

            var putResponse = await _testsFixture.Client.PutAsJsonAsync($"api/book/{book.Id}", book);

            putResponse.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Update Book With Nonstandard ISBN")]
        [Trait("Category", "Integration API - Book")]
        public async Task UpdateBookWithNonStandardISBN_MustReturnUnsuccessfully()
        {

            var book = new BookViewModel
            {
                Id = new Guid("e1466a05-2df0-41e3-81a2-08d78b4a656e"),
                Title = "TDD",
                ReleaseDate = Convert.ToDateTime("2015-02-04"),
                ISBN = "555-66-777-8888-999",
                Category = "Dev"
            };

            await _testsFixture.LoginApi();
            _testsFixture.Client.AssignToken(_testsFixture.UserToken);

            var putResponse = await _testsFixture.Client.PutAsJsonAsync($"api/book/{book.Id}", book);

            putResponse.EnsureSuccessStatusCode();
        }

        [Fact(DisplayName = "Delete Book")]
        [Trait("Category", "Integration API - Book")]
        public async Task DeleteBook_MustReturnSuccessfully()
        {

            var book = new BookViewModel
            {
                Id = new Guid("e1466a05-2df0-41e3-81a2-08d78b4a656e")
            };

            await _testsFixture.LoginApi();
            _testsFixture.Client.AssignToken(_testsFixture.UserToken);

            var deleteResponse = await _testsFixture.Client.DeleteAsync($"api/book/{book.Id}");

            deleteResponse.EnsureSuccessStatusCode();
        }
    }
}
