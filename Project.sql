
drop database Project_DB;
create database Project_DB;

use Project_DB;

drop table SignInDetails;
drop table PersonalDetails;
drop table Addresses;

create table SignInDetails(
EmailAddress varchar(50) primary key,
Firstname varchar(50),
Surname varchar(50),
Upassword varchar(100)
);

create table Vital(
VitalID int identity(1,1) primary key, 
Heart Rate int,
Blood Pressure int,
Blood Sugar int,
Iron Levels int,
White Blood Cell int, 
Red Blood Cell int,
Antibodies int,
Iron Level int,
 )

create table PersonalDetails(
IDNumber varchar(20) primary key,
Age int not null,
ContactDetails varchar(20),
EmailAddress varchar(50),
/*Still have to add address*/
AddressID int,
foreign key (EmailAddress) references SignInDetails(EmailAddress),
);

Create table Address(
AddressID int identity(1,1) primary key,
Province varchar(20),
City varchar(20),
StreetName varchar(20),
HouseNumber varchar(20),
IDNumber varchar(20),
foreign key (IDNumber) references PersonalDetails(IDNumber)
);

Alter table PersonalDetails add constraint AddressID foreign key(AddressID) references Addresses(AddressID) ON DELETE CASCADE    
      ON UPDATE CASCADE;

