Begin Transaction

INSERT INTO [dbo].[Genres]
           ([GenreType])
     VALUES
('Fiction')
,('Non Fiction')

INSERT INTO [dbo].[Books]
           ([Id]
           ,[Title]
           ,[Author]
           ,[Rating]
           ,[Reviews]
           ,[Price]
           ,[Year]
           ,[GenreId])
     VALUES
 (NEWID() ,'10-Day Green Smoothie Cleanse','JJ Smith', 4.7, 17350, 8, 2016, 1)
,(NEWID(),'11/22/63: A Novel','Stephen King',4.6,2052,22,2011,1)
,(NEWID(),'12 Rules for Life: An Antidote to Chaos','Jordan B. Peterson',4.7,18979,15,2018,2)
,(NEWID(),'1984 (Signet Classics)','George Orwell',4.7,21424,6,2017,1)
,(NEWID(),'5,000 Awesome Facts (About Everything!) (National Geographic Kids)','National Geographic Kids',4.8,7665,12,2019,2)
,(NEWID(),'A Dance with Dragons (A Song of Ice and Fire)','George R. R. Martin',4.4,12643,11,2011,1)
,(NEWID(),'A Game of Thrones / A Clash of Kings / A Storm of Swords / A Feast of Crows / A Dance with Dragons','George R. R. Martin',4.7,19735,30,2014,1)
,(NEWID(),'A Gentleman in Moscow: A Novel','Amor Towles',4.7,19699,15,2017,1)
,(NEWID(),'A Higher Loyalty: Truth, Lies, and Leadership','James Comey',4.7,5983,3,2018,2)
,(NEWID(),'A Man Called Ove: A Novel','Fredrik Backman',4.6,23848,8,2016,1)

INSERT INTO [dbo].[Members]
           ([FirstName]
           ,[LastName]
           ,[Phone]
           ,[Email])
     VALUES
('Bob', 'Member', '907-555-1212', 'test@email.com')
,('Deb', 'Patron', '907-555-1212', 'test@email.com')
,('John', 'Long', '907-555-1212', 'test@email.com')

commit