This program is a store simulator.
It stores recepes which are collected in a recepe book.

The recepe books have an ID, Name and a List of Foods.
In this current state we have 3 type of foods. 
	-Appetizer
	-Second Meal
	-Dessert
These foods have some unique properties.
For instance the Second Meal has a NeedToCook, PreparingTime and List of spices property.

When the program starts it tries to load data from store.xml.
If the searching was not successfull you have to create RecipeBooks first (press 2).

If you press 1 you can see all of the RecepeBooks.

When you have a RecepeBook you can modify it by it's ID (press 3).
	In this menu you can:
		-Delete food recepes.
		-Add new food recepes.
		-Comment to food recepes.
		-Go back to the book choosing.
		
You can delete existing RecepeBooks by ID (press 4).

See what RecepeBook(s) contain food. You only need the food's name here (press 5).

See RecepeBook's content by book's ID (press 6).

You save to the xml (press 7).