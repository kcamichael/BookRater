July 13, 2023
Red Panda Group
Book Rater API v1.0

Purpose: We built an easy-to-use app that book lovers of all age-ranges and reading levels can use.

After cloning the code from GitHub you will need to run a dotnet build to make sure you have the right DOTNET assembly.

After that make sure you are "cd'd" into the project and type: dotnet watch run --project .\BookRater.API\

Now you can begin searching for books, genres, authors and reviews in Swagger!

___________________________________________________________________________________________________________________________________

To find a book, navigate to the "Book" section of the API.

You can find a book by it's ID in the GET dropdown that says /api/Book/{id}.

You can list books by by their genre in the GET dropdown that says /Genre/GenreId/.

You can list books by by their author in the GET dropdown that says /AuthorSearch/AuthorId/.

You can list all books in the GET drop down that says /api/Book/.

You can create a new book entry by using the POST dropdown that says /api/Book/.

You can delete a book entry by using the DELETE dropdown that says /api/Book/{id}.

You can edit a book entry by using the PUT dropdown that says /api/Book/{id}.

___________________________________________________________________________________________________________________________________

GENRE Section:
Add a Genre by using the POST Dropdown. Green rectangle box.

Delete a Genre by using the DELETE Dropdown. Red rectangle box. Only need to input the ID assigned to the GENRE.

Edit a Genre by using the PUT Dropdown. Orange/Yellow rectangle box. Need to input the ID assigned to the GENRE TWICE and the new name ONCE.

View all Genres by using the GET Dropdown. Blue rectangle box.

___________________________________________________________________________________________________________________________________

USER Section:
Create user account by using the POST Dropdown. Green rectangle box. (/api/Accounts/Register)

Login to created account by using the POST Dropdown. Green rectangle box. (api/Accounts/Login)
___________________________________________________________________________________________________________________________________
