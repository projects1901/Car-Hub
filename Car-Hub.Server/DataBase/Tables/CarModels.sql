CREATE TABLE CarModels (
    CarModelId INT IDENTITY(1,1) PRIMARY KEY,          
    Brand NVARCHAR(50) NOT NULL,                      
    Class NVARCHAR(50) NOT NULL,                      
    ModelName NVARCHAR(100) NOT NULL,                 
    ModelCode NVARCHAR(10) NOT NULL,                  
    Description NVARCHAR(MAX) NOT NULL,               
    Features NVARCHAR(MAX) NOT NULL,                  
    Price DECIMAL(18, 2) NOT NULL,                    
    DateOfManufacturing DATETIME NOT NULL,            
    IsActive BIT NOT NULL,                            
    SortOrder INT NOT NULL,                           
    ModelImage VARBINARY(MAX),                        
    CreatedAt DATETIME DEFAULT GETDATE(),             
    UpdatedAt DATETIME DEFAULT GETDATE()              
);