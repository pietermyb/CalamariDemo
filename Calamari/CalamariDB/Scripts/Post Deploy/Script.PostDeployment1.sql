/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

-- PRODUCT TABLE --
SET IDENTITY_INSERT [dbo].[Product] ON

MERGE INTO [dbo].[Product] AS Target
USING(VALUES
		(1, 'd3cac20f-a57f-48cb-a47a-356aff5b23ae','Battered Rings','1Kg Calamari Rings in Batter.',120),
		(2, '3c9f12fa-3079-4b39-a1f7-a3bf0193223e','Griller Rings','1Kg Calamari Rings.',80),
		(3, '262d6309-9f29-45d9-8716-0e2f24929a55','Steaks','1Kg Calamari steaks.',120),
		(4, 'f1b89cdc-e900-4ffd-99fb-81130a9bf132','Tubes','1Kg Calamari tubes, great for stuffing.',120),
		(5, '2f654ded-f8c1-48ca-b1ab-a3c7070f5140','Tentacles','500grams Calamari Heads with tentacles.',80),
		(6, '2643489c-4942-4e1f-9b77-5c9e1c9a773f','Mix','1Kg Party Mix',120)
		)
		AS SOURCE([ID],[RefID],[Name],[Description],[Price])
		ON Target.Id = Source.Id

WHEN MATCHED THEN
UPDATE SET
	[RefId] = Source.[RefId],
	[Name] = Source.[Name],
	[Description] = Source.[Description],
	[Price] = Source.[Price]

WHEN NOT MATCHED BY TARGET THEN
INSERT([ID],[RefID],[Name],[Description],[Price])
VALUES([ID],[RefID],[Name],[Description],[Price])

WHEN NOT MATCHED BY SOURCE THEN
DELETE;

SET IDENTITY_INSERT [dbo].[Product] OFF