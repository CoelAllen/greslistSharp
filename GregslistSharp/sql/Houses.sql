CREATE TABLE
    IF NOT EXISTS houses(
        id int NOT NULL AUTO_INCREMENT PRIMARY KEY,
        bedrooms int NOT NULL CHECK(bedrooms >= 1),
        floors int NOT NULL CHECK(floors >= 1),
        year int,
        description VARCHAR(255),
        price DECIMAL (10, 2) NOT NULL CHECK(price >= 0),
        imgUrl VARCHAR(255) DEFAULT "https://www.moneyunder30.com/wp-content/uploads/2017/11/405_How-To-Sell-Your-House-%E2%80%9CBy-Owner%E2%80%9D-%E2%80%93-By-Yourself-648x364-c-default.jpg"
    );

INSERT INTO
    houses(
        bedrooms,
        floors,
        year,
        description,
        price,
        imgUrl
    )
VALUES (
        "2",
        "1",
        1965,
        100000,
        "Beautiful home!",
        "https://www.pinoyhouseplans.com/wp-content/uploads/2019/08/Modern-single-storey-house-06.jpg"
    );

SELECT * FROM houses;