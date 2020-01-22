DROP DATABASE IF EXISTS to_do_list;
CREATE DATABASE to_do_list;
USE to_do_list;

CREATE TABLE to_do_list.Categories(
			 CategoryId INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
             `name` VARCHAR(25) NOT NULL
);
CREATE TABLE to_do_list.Items(
			ItemId INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
            CategoryId INT NOT NULL,
            description VARCHAR(255) NOT NULL,
            CONSTRAINT fk_categories_categoryId FOREIGN KEY (CategoryId) REFERENCES Categories(CategoryId)
);



                    