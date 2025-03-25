CREATE TABLE Products (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    BrandName VARCHAR(255) NOT NULL,
    ProductName VARCHAR(255) NOT NULL,
    SuggestedPrice DECIMAL(10,2) NOT NULL,
    CreatedAt TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO Products (BrandName, ProductName, SuggestedPrice) VALUES
('Apple', 'iPhone 15', 799.99),
('Samsung', 'Galaxy S23', 699.99),
('Xiaomi', 'Redmi Note 12', 299.99),
('Google', 'Pixel 7', 599.99);
