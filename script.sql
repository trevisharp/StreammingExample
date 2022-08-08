use master
go

if (exists(select * from sys.databases where name = 'StreammingDB'))
	drop database StreammingDB
go

create database StreammingDB
go

use StreammingDB
go

create table Content(
	ID int identity primary key,
	Bytes varbinary(MAX) not null
)