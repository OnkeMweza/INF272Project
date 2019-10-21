
drop database Project_DB;
create database Project_DB;

use Project_DB;

drop table SignInDetails;
drop table PersonalDetails;
drop table Addresses;

/*create table SignInDetails(
EmailAddress varchar(50) primary key,
Firstname varchar(50),
Surname varchar(50),
Upassword varchar(100)
);*/

create table Vital(
VitalID int identity(1,1) primary key, 
HeartRate int,
BloodPressure int,
BloodSugar int,
IronLevels int,
WhiteBloodCells int, 
RedBloodCells int,
Antibodies int,
IronLevel int,
 )

/*create table PersonalDetails(
IDNumber varchar(20) primary key,
Age int not null,
ContactDetails varchar(20),
EmailAddress varchar(50),
/*Still have to add address*/
AddressID int,
foreign key (EmailAddress) references SignInDetails(EmailAddress),
);*/

create table UserType(
UTID int identity(1,1) primary key,
UTDescription varchar(50)
);

insert into UserType(UTDescription)
values
('Patient'),
('Admin');

create table PatientRelative(
RID int identity(1,1) primary key,
FirstName varchar(50),
Surname varchar(50),
ContactDetailsP char(10),
ContactDetailsH char(10),
ContactDetailsW char(10),
);

create table Illness(
IID int identity(1,1) primary key,
IllnessName varchar(50)
);

create table Surbub(
SurbubID int identity(1,1) primary key,
SurbubName varchar(50),
);

create table Street(
StreetID int identity(1,1) primary key,
StreetName varchar(50),
HouseNO int,
SurbubID int,
foreign key (SurbubID) references Surbub(SurbubID)

);

Create table UAddress(
AID int identity(1,1) primary key,
StreetID int,
foreign key (StreetID) references Street(StreetID)
);

create table Patient(
FirstName varchar(50),
Surname varchar(50),
EmailAddress varchar(50) primary key,
Age int,
ContactDetails char(10),
ChipID char(10),
/*IllnessID FK
MedAid FK
Vitals
Relatives
Address*/

VitalID int,
foreign key (VitalID) references Vital(VitalID),
RID int,
foreign key (RID) references PatientRelative(RID),
IID int,
foreign key (IID) references Illness(IID),
AID int,
foreign key (AID) references UAddress(AID)
);

create table SysAdmin(
EmailAddress varchar(50) primary key,
FirstName varchar(50),
Surname varchar(50),
ContactDetails char(10)
)

create table AppUser(
userID int identity(1,1),
EmailAddress varchar(50),	/*Foreign key*/
Upassword varchar(50),
/*Foreign key to usertype table*/
UTID int,
foreign key (UTID) references UserType(UTID),
foreign key(EmailAddress) references Patient(EmailAddress)/*Not sure about this because there's 2 tables, Patients and Admins**/
);




/*Alter table AppUser add constraint EmailAddress foreign key(EmailAddress) references Patient(EmailAddress) ON DELETE CASCADE    
      ON UPDATE CASCADE;*/

