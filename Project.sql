
drop database Project_DB;

create database Project_DB;

drop table Hospital;

use Project_DB;
alter table Street
drop column HouseNO1;
alter table UAddress
add HouseNO int;
alter table Street
add HouseNO int;
create table MedicalAid(

MID int identity(1,1) primary key,

MedicalAidName varchar(50)

);



create table Vital(

VitalID int identity(1,1) primary key, 

HeartRate int,

BloodPressure int,

BloodSugar int,

IronLevels int,

WhiteBloodCells int, 

RedBloodCells int,

Antibodies int,

Glucose int,

Cholesterol int

 );



create table UserType(

UTID int identity(1,1) primary key,

UTDescription varchar(50)

);



insert into UserType(UTDescription)

values

('Patient'),

('Admin');

create table SysUser(

userID int identity(1,1) primary key,

EmailAddress varchar(50),	/*Foreign key*/

Upassword varchar(50),

/*Foreign key to usertype table*/

UTID int,

foreign key (UTID) references UserType(UTID),
);

create table SysAdmin(

AdminID int identity(1,1) primary key,

EmailAddress varchar(50) unique,

FirstName varchar(50),

Surname varchar(50),

ContactDetails char(10),
userID int,

foreign key (userID) references SysUser(userID),

);

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

SurbubID int,

foreign key (SurbubID) references Surbub(SurbubID)



);



Create table UAddress(

AID int identity(1,1) primary key,

StreetID int,
HouseNO int,


foreign key (StreetID) references Street(StreetID)

);



create table Patient(

PatientID int identity(1,1) primary key,

FirstName varchar(50),

Surname varchar(50),

EmailAddress varchar(50) unique,

Age int,

ContactDetails char(10),

ChipID char(10),

/*IllnessID FK

MedAid FK

Vitals

Relatives

Address*/
MID int,
foreign key (MID) references MedicalAid(MID),


VitalID int,

foreign key (VitalID) references Vital(VitalID),

RID int,

foreign key (RID) references PatientRelative(RID),

IID int,

foreign key (IID) references Illness(IID),

AID int,

foreign key (AID) references UAddress(AID),

userID int,

foreign key (userID) references SysUser(userID),

);





create table Hospital(

HID int identity(1,1) primary key,

HospitalName varchar(50),

ContactDetails char(10),

AID int,

foreign key (AID) references UAddress(AID)

);



create table Partner(

PID int identity(1,1) primary key,

PartnerName varchar(50),

ContactDetails char(10)

);





/*Alter table AppUser add constraint EmailAddress foreign key(EmailAddress) references Patient(EmailAddress) ON DELETE CASCADE    

      ON UPDATE CASCADE;*/