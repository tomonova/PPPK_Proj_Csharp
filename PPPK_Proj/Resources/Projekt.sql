create database PPPK_PROJ2
use PPPK_PROJ2

create table VOZACI
(
	IDVozac int not null identity(1,1),
	Ime nvarchar(max) not null,
	Prezime nvarchar(max) not null,
	Mobitel nvarchar(max) ,
	VozackaDozvola nvarchar(max) not null,
	VozacStatus int default(1),
	constraint PKVozaci primary key(IDvozac),
);

create table VOZILA
(
	IDVozilo int not null identity(1,1),
	Marka nvarchar(max) not null,
	Tip nvarchar(max) not null,
	GodinaProizvodnje date not null default (GETDATE()) ,
	GodinaUnosa date not null default (GETDATE()) ,
	InicijalniKM int not null default(0),
	constraint PKVozila primary key(IDVozilo)
);
create table DRZAVE
(
	IDDrzava int not null identity(1,1),
	Naziv nvarchar(max),
	constraint PKDrzave primary key(IDDrzava)
)
create table GRADOVI
(
	IDGrad int not null identity(1,1),
	Ime nvarchar(max) not null,
	Latitutde decimal(9,6) not null,
	Longitude decimal(9,6) not null,
	DrzavaID int not null,
	constraint FKGradovi_Drzave foreign key (DrzavaID) references DRZAVE(IDDrzava),
	constraint PKGradovi primary key(IDGrad)
)
create table PUTNI_NALOZI
(
	IDNalog int not null identity(1,1),
	Otvaranje datetime,
	Zatvaranje datetime,
	VozacID int,
	VoziloID int,
	MjestoStartID int,
	MjestoCiljID int,
	constraint FKPutniNalozi_Vozaci foreign key (VozacID) references VOZACI(IDVozac),
	constraint FKPutniNalozi_Vozila foreign key (VoziloID) references VOZILA(IDVozilo),
	constraint FKPutniNalozi_MjestoStart foreign key (MjestoStartID) references GRADOVI(IDGrad),
	constraint FKPutniNalozi_MjestoCilj foreign key (MjestoCiljID) references GRADOVI(IDGrad),
	StatusNaloga int,
	constraint PKPutniNalozi primary key(IDNalog)
)
create table SERVISNA_KNJIGA
(
	IDServis int not null identity(1,1),
	VoziloID int,
	constraint FKServisnaKnjiga_Vozila foreign key (VoziloID) references VOZILA(IDVozilo),
	Datum date not null,
	Trosak decimal(10,2) not null default(0)
	constraint PKServisnaKnjiga primary key(IDServis)
)
go
create or alter proc DBCLEAN
as
	delete from PUTNI_NALOZI
	delete from SERVISNA_KNJIGA
	delete from VOZILA
	delete from VOZACI
	delete from GRADOVI
	delete from DRZAVE
go
create or alter proc GetVozaci
as
	select * from VOZACI
	where VozacStatus = 1;
go
create or alter proc GetVozac
	@IDVozac int
as
	select * from VOZACI
	where IDVozac=@IDVozac
	and VozacStatus = 1
go
create or alter proc AddVozac
	@Ime nvarchar(max),
	@Prezime nvarchar(max),
	@Mobitel nvarchar(max),
	@VozackaDozvola nvarchar(max)
as
	insert into VOZACI(Ime, Prezime, Mobitel, VozackaDozvola)
	values(@Ime,@Prezime,@Mobitel,@VozackaDozvola)
go
create or alter proc DelVozac
	@IDVozac int
as
	update VOZACI
	set VozacStatus = 2
	where IDVozac=@IDVozac
go

create or alter proc EditVozac
	@IDVozac int,
	@Ime nvarchar(max),
	@Prezime nvarchar(max),
	@Mobitel nvarchar(max),
	@VozackaDozvola nvarchar(max)
as
	update VOZACI
	set Ime=@Ime, Prezime=@Prezime, Mobitel=@Mobitel, VozackaDozvola=@VozackaDozvola
	where IDvozac=@IDVozac
go
create or alter proc GetGradoviCB
as
	select IDgrad,Ime from GRADOVI
	order by 2 asc
go
create or alter proc GetVozaciCB
as
	select IDVozac,Prezime +' '+ Ime as PrezimeIme from vozaci
	order by 2 asc
go
create or alter proc GetVozilaCB
as
	select IDVozilo,Marka+' '+Tip as Vozilo from VOZILA
	order by 2 asc
go
create or alter view V_PutniNalozi
as
	select pn.IDNalog, pn.Otvaranje as OtvaranjeNaloga,pn.Zatvaranje as ZatvaranjeNaloga,v.Prezime + ' ' + v.Ime as Vozac, vz.Marka +' '+vz.Tip as Vozilo, gs.Ime as MjestoStart, gc.Ime as MjestoCilj,StatusNaloga from PUTNI_NALOZI pn
	left join VOZACI v on v.IDVozac = pn.VozacID
	left join VOZILA vz on vz.IDVozilo = pn.VoziloID
	left join GRADOVI gs on gs.IDGrad = pn.MjestoStartID
	left join GRADOVI gc on gc.IDGrad = pn.MjestoCiljID
go
create or alter proc GetPutniNalozi
	@StatusNaloga int
as
	if (@StatusNaloga = 0)
		select * from V_PutniNalozi
		order by 1 desc;
	else
		select * from V_PutniNalozi
		where StatusNaloga=@StatusNaloga
		order by 1 desc;
go
create or ALTER proc DelPutniNalog
	@IDNalog int
as
	delete from PUTNI_NALOZI
	where IDNalog=@IDNalog
go
create or alter proc GetMjestoStart
	@IDNalog int
as
	select MjestoStartID from PUTNI_NALOZI
	where IDNalog=@IDNalog
go
create or alter proc GetMjestoCilj
	@IDNalog int
as
	select MjestoCiljID from PUTNI_NALOZI
	where IDNalog=@IDNalog
go
create or alter proc GetStatusNalogaPN
	@IDNalog int
as
	select StatusNaloga from PUTNI_NALOZI
	where IDNalog=@IDNalog
go
create or alter proc GetVoziloPN
	@IDNalog int
as
	select VoziloID from PUTNI_NALOZI
	where IDNalog=@IDNalog
go
create or alter proc GetVozacPN
	@IDNalog int
as
	select VozacID from PUTNI_NALOZI
	where IDNalog=@IDNalog
go
create or alter proc GetTime
	@IDNalog int,
	@TipVremena nvarchar(15)
as
	if @TipVremena = 'Otvaranje'
		select Otvaranje from PUTNI_NALOZI
		where IDNalog=@IDNalog
	else
		select Zatvaranje from PUTNI_NALOZI
		where IDNalog=@IDNalog
go
create or alter proc AddEditPN
	@IDNalog int,
	@Otvaranje datetime,
	@Zatvaranje datetime,
	@VozacID int,
	@VoziloID int,
	@MjestoStartID int,
	@MjestoCiljID int,
	@StatusNaloga int
as
	if @IDNalog = 0
		insert into PUTNI_NALOZI(Otvaranje, Zatvaranje, VozacID, VoziloID, MjestoStartID, MjestoCiljID, StatusNaloga)
		values(@Otvaranje,@Zatvaranje,@VozacID,@VoziloID,@MjestoStartID,@MjestoCiljID,@StatusNaloga)
	else
		update PUTNI_NALOZI
		set Otvaranje=@Otvaranje,
			Zatvaranje=@Zatvaranje,
			VozacID=@VozacID,
			VoziloID=@VoziloID,
			MjestoStartID=@MjestoStartID,
			MjestoCiljID=@MjestoCiljID,
			StatusNaloga=@StatusNaloga
		where IDNalog = @IDNalog
go
create or alter proc AddVozilo
	@Marka nvarchar(max),
	@Tip nvarchar(max),
	@GodinaProizvodnje Date,
	@GodinaUnosa Date,
	@IncijalniKm int
as
	insert into VOZILA(Marka,Tip, GodinaProizvodnje, GodinaUnosa, InicijalniKM)
	values(@Marka,@Tip,@GodinaProizvodnje,@GodinaUnosa,@IncijalniKm)
go
create or alter proc AddDrzava
	@Naziv nvarchar(max)
as
	insert into DRZAVE(Naziv)
	values(@Naziv)
go
create or alter proc AddGrad
	@Ime nvarchar(max),
	@Latitude decimal(9,6),
	@Longitude decimal(9,6),
	@DrzavaID int
as
	insert into GRADOVI(Ime,Latitutde,Longitude,DrzavaID)
	values(@Ime,@Latitude,@Longitude,@DrzavaID)
go
create or alter proc GetGradovi
as
	select * from GRADOVI
go
create or alter proc GetVozila
as
	select * from Vozila
go
create or alter PROC GetVozilaFree
	@Otvaranje datetime,
	@Zatvaranje datetime
AS 
	select IDVozilo,Marka+' '+Tip as Vozilo from VOZILA 
	where IDVozilo not in
	(
		select distinct(voziloid) from PUTNI_NALOZI
		where (@Zatvaranje > Otvaranje and @Zatvaranje < Zatvaranje)
		or (@Otvaranje > Otvaranje and @Zatvaranje < Zatvaranje)
		or (@Otvaranje< Zatvaranje and @Zatvaranje > Zatvaranje)
	)
	order by 2 asc
go
create or alter proc GetVozaciFree
	@Otvaranje datetime,
	@Zatvaranje datetime
AS 
	select IDVozac,Prezime +' '+ Ime as PrezimeIme from VOZACI 
	where IDVozac not in
	(
		select distinct(vozacID) from PUTNI_NALOZI
		where (@Zatvaranje > Otvaranje and @Zatvaranje < Zatvaranje)
		or (@Otvaranje > Otvaranje and @Zatvaranje < Zatvaranje)
		or (@Otvaranje< Zatvaranje and @Zatvaranje > Zatvaranje)
	)
	order by 2 asc
go
create or alter proc DBINIT
as
	insert into SERVISNA_KNJIGA(VoziloID, Datum, Trosak) values((select IDVozilo from (select row_number() over (order by (select null)) as ROWNUM,IDVozilo from VOZILA) x
		where ROWNUM = (select round((SELECT RAND()*(3-0)+1),0))),'2020-10-29',1345.55)
	insert into SERVISNA_KNJIGA(VoziloID, Datum, Trosak) values((select IDVozilo from (select row_number() over (order by (select null)) as ROWNUM,IDVozilo from VOZILA) x
		where ROWNUM = (select round((SELECT RAND()*(3-0)+1),0))),'2020-09-12',1622.00)
	insert into SERVISNA_KNJIGA(VoziloID, Datum, Trosak) values((select IDVozilo from (select row_number() over (order by (select null)) as ROWNUM,IDVozilo from VOZILA) x
		where ROWNUM = (select round((SELECT RAND()*(3-0)+1),0))),'2020-11-11',985.35)
	insert into PUTNI_NALOZI(Otvaranje, Zatvaranje, VozacID, VoziloID, MjestoStartID, MjestoCiljID, StatusNaloga)
		values('2019-04-13 09:00:12','2019-05-05 11:13:22',
		(select IDVozac from (select row_number() over (order by (select null)) as ROWNUM,IDVozac from VOZACI) x
		where ROWNUM = (select round((SELECT RAND()*(5-0)+1),0))),
		(select IDVozilo from (select row_number() over (order by (select null)) as ROWNUM,IDVozilo from VOZILA) x
		where ROWNUM = (select round((SELECT RAND()*(3-0)+1),0))),
		(select IDGrad from (select row_number() over (order by (select null)) as ROWNUM,IDGrad from GRADOVI) x
		where ROWNUM = (select round((SELECT RAND()*(500-0)+1),0))),
		(select IDGrad from (select row_number() over (order by (select null)) as ROWNUM,IDGrad from GRADOVI) x
		where ROWNUM = (select round((SELECT RAND()*(500-0)+1),0))),1)
	insert into PUTNI_NALOZI(Otvaranje, Zatvaranje, VozacID, VoziloID, MjestoStartID, MjestoCiljID, StatusNaloga)
		values('2020-07-13 09:30:12','2020-07-25 19:19:22',
		(select IDVozac from (select row_number() over (order by (select null)) as ROWNUM,IDVozac from VOZACI) x
		where ROWNUM = (select round((SELECT RAND()*(5-0)+1),0))),
		(select IDVozilo from (select row_number() over (order by (select null)) as ROWNUM,IDVozilo from VOZILA) x
		where ROWNUM = (select round((SELECT RAND()*(3-0)+1),0))),
		(select IDGrad from (select row_number() over (order by (select null)) as ROWNUM,IDGrad from GRADOVI) x
		where ROWNUM = (select round((SELECT RAND()*(500-0)+1),0))),
		(select IDGrad from (select row_number() over (order by (select null)) as ROWNUM,IDGrad from GRADOVI) x
		where ROWNUM = (select round((SELECT RAND()*(500-0)+1),0))),2)	
	insert into PUTNI_NALOZI(Otvaranje, Zatvaranje, VozacID, VoziloID, MjestoStartID, MjestoCiljID, StatusNaloga)
		values('2020-07-21 09:15:12','2020-07-29 16:13:22',
		(select IDVozac from (select row_number() over (order by (select null)) as ROWNUM,IDVozac from VOZACI) x
		where ROWNUM = (select round((SELECT RAND()*(5-0)+1),0))),
		(select IDVozilo from (select row_number() over (order by (select null)) as ROWNUM,IDVozilo from VOZILA) x
		where ROWNUM = (select round((SELECT RAND()*(3-0)+1),0))),
		(select IDGrad from (select row_number() over (order by (select null)) as ROWNUM,IDGrad from GRADOVI) x
		where ROWNUM = (select round((SELECT RAND()*(500-0)+1),0))),
		(select IDGrad from (select row_number() over (order by (select null)) as ROWNUM,IDGrad from GRADOVI) x
		where ROWNUM = (select round((SELECT RAND()*(500-0)+1),0))),3)
	insert into PUTNI_NALOZI(Otvaranje, Zatvaranje, VozacID, VoziloID, MjestoStartID, MjestoCiljID, StatusNaloga)
		values('2019-06-17 09:00:12','2019-06-25 14:23:22',
		(select IDVozac from (select row_number() over (order by (select null)) as ROWNUM,IDVozac from VOZACI) x
		where ROWNUM = (select round((SELECT RAND()*(5-0)+1),0))),
		(select IDVozilo from (select row_number() over (order by (select null)) as ROWNUM,IDVozilo from VOZILA) x
		where ROWNUM = (select round((SELECT RAND()*(3-0)+1),0))),
		(select IDGrad from (select row_number() over (order by (select null)) as ROWNUM,IDGrad from GRADOVI) x
		where ROWNUM = (select round((SELECT RAND()*(500-0)+1),0))),
		(select IDGrad from (select row_number() over (order by (select null)) as ROWNUM,IDGrad from GRADOVI) x
		where ROWNUM = (select round((SELECT RAND()*(500-0)+1),0))),1)
	insert into PUTNI_NALOZI(Otvaranje, Zatvaranje, VozacID, VoziloID, MjestoStartID, MjestoCiljID, StatusNaloga)
		values('2020-10-13 09:00:12','2020-10-15 11:13:22',
		(select IDVozac from (select row_number() over (order by (select null)) as ROWNUM,IDVozac from VOZACI) x
		where ROWNUM = (select round((SELECT RAND()*(5-0)+1),0))),
		(select IDVozilo from (select row_number() over (order by (select null)) as ROWNUM,IDVozilo from VOZILA) x
		where ROWNUM = (select round((SELECT RAND()*(3-0)+1),0))),
		(select IDGrad from (select row_number() over (order by (select null)) as ROWNUM,IDGrad from GRADOVI) x
		where ROWNUM = (select round((SELECT RAND()*(500-0)+1),0))),
		(select IDGrad from (select row_number() over (order by (select null)) as ROWNUM,IDGrad from GRADOVI) x
		where ROWNUM = (select round((SELECT RAND()*(500-0)+1),0))),2)
	insert into PUTNI_NALOZI(Otvaranje, Zatvaranje, VozacID, VoziloID, MjestoStartID, MjestoCiljID, StatusNaloga)
		values('2020-11-23 11:00:12','2020-11-29 17:45:22',
		(select IDVozac from (select row_number() over (order by (select null)) as ROWNUM,IDVozac from VOZACI) x
		where ROWNUM = (select round((SELECT RAND()*(5-0)+1),0))),
		(select IDVozilo from (select row_number() over (order by (select null)) as ROWNUM,IDVozilo from VOZILA) x
		where ROWNUM = (select round((SELECT RAND()*(3-0)+1),0))),
		(select IDGrad from (select row_number() over (order by (select null)) as ROWNUM,IDGrad from GRADOVI) x
		where ROWNUM = (select round((SELECT RAND()*(500-0)+1),0))),
		(select IDGrad from (select row_number() over (order by (select null)) as ROWNUM,IDGrad from GRADOVI) x
		where ROWNUM = (select round((SELECT RAND()*(500-0)+1),0))),3)
		

		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		
		