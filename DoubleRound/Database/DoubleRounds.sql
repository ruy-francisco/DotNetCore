create table DoubleRounds (
	Id int not null identity,
	BeginDate datetime2 not null,
	EndDate datetime2 not null,
	Place varchar(100) not null,
	Latitude decimal(18, 10) not null,
	Longitude decimal(18, 10) not null,
	PlaceId varchar(100),
	PlaceAddress varchar(500) not null,
	constraint pk_doublerounds primary key (Id)
);

--drop table DoubleRounds
-- select * from DoubleRounds