USE Cars ; 
CREATE TABLE Users(UserID int  PRIMARY KEY NOT NULL ,
					FirstName CHAR(20) NOT NULL,
					LastName CHAR(20) NOT NULL,
					Email CHAR(30) NOT NULL,
					Password CHAR(30) NOT NULL,	
					);

CREATE TABLE Customers(
					CustomersID int  PRIMARY KEY NOT NULL ,
				    UserID INT FOREIGN KEY REFERENCES Users(UserID) NoT NULL , 
					CompanyName CHAR(30) NOT NULL
					);
CREATE TABLE Rentals(
					 RentalsID int  PRIMARY KEY NOT NULL ,
				     CarId INT FOREIGN KEY REFERENCES Cars(CarId) NoT NULL , 
				     CustomersID INT FOREIGN KEY REFERENCES Customers(CustomersID) NoT NULL , 
					 RentDate DATETIME NOT NULL,
					 ReturnDate DATETIME 
					);

