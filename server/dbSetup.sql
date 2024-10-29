CREATE TABLE IF NOT EXISTS accounts(
  id VARCHAR(255) NOT NULL primary key,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  name varchar(255) COMMENT 'User Name',
  email varchar(255) UNIQUE COMMENT 'User Email',
  picture varchar(255) COMMENT 'User Picture',
  coverImg VARCHAR(1000)
) default charset utf8mb4 COMMENT '';

ALTER TABLE accounts ADD COLUMN coverImg VARCHAR(1000);

CREATE TABLE IF NOT EXISTS keeps (
  id int NOT NULL primary key AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  name VARCHAR(255) NOT NULL,
  description VARCHAR(1000) NOT NULL,
  img VARCHAR(1000) NOT NULL,
  views INT NOT NULL DEFAULT 0,
  creatorId VARCHAR(255) NOT NULL,
  Foreign Key (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS vaults (
  id int NOT NULL primary key AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  name VARCHAR(255) NOT NULL,
  description VARCHAR(1000),
  img VARCHAR(1000) NOT NULL,
  isPrivate BOOLEAN NOT NULL DEFAULT False,
  creatorId VARCHAR(255) NOT NULL,
  Foreign Key (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
);

INSERT INTO 
  vaults(name, img, creatorId)
  VALUES('Pokemon', 'https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTiYT3bZ3je2oFM95saHalf5HVqcYHTcmk54w&s','66f32093b4e1c932f63ed63a');
  Select 
    vaults.*,
    accounts.*
    from vaults
    JOIN accounts ON accounts.Id = vaults.creatorId
    WHERE vaults.id = LAST_INSERT_ID();

create TABLE IF NOT EXISTS vaultKeeps (
  id int NOT NULL primary key AUTO_INCREMENT,
  createdAt DATETIME DEFAULT CURRENT_TIMESTAMP,
  updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  keepId Int NOT NULL,
  vaultId Int NOT NULL,
  creatorId VARCHAR(255) NOT NULL,
  Foreign Key (creatorId) REFERENCES accounts (id) ON DELETE CASCADE,
  Foreign Key (vaultId) REFERENCES vaults (id) ON DELETE CASCADE,
  Foreign Key (keepId) REFERENCES keeps (id) ON DELETE CASCADE,
  UNIQUE (keepId, vaultId)
);

ALTER TABLE vaultKeeps 
DROP UNIQUE KEY;

show indexes from `vaultKeeps`

Insert INTO 
vaultKeeps(`keepId`, `vaultId`, `creatorId`)
VALUES(4, 1, '66e04bf70483818f681bcaa1')

DROP Table vaults


INSERT INTO 
      keeps(name, description, img, creatorId)
      VALUES('Amazing View', 'Great view from a top of a mountain', 'https://www.travelandleisure.com/thmb/H_LyBQJ3AZKfg_HGYY5tOH3niB0=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/blue-ridge-mountains-USMNTNS0720-c68c0141d720475aa179bace8858fbd1.jpg', '66e04bf70483818f681bcaa1')



  SELECT 
      keeps.*, COUNT(
        vaultKeeps.keepId
      ) as kept,
      accounts.*
   FROM 
    keeps
    Join accounts ON accounts.id = keeps.creatorId
    LEFT OUTER JOIN vaultKeeps ON vaultKeeps.keepId = keeps.id
  GROUP BY
    keeps.id



    SELECT 
      keeps.*, COUNT(
        vaultKeeps.keepId
      ) as kept,
      accounts.*
   FROM 
    keeps
    Join accounts ON accounts.id = keeps.creatorId
    LEFT OUTER JOIN vaultKeeps ON vaultKeeps.keepId = keeps.id
  WHERE keeps.id = 1
  GROUP BY
    keeps.id


    UPDATE keeps SET views = views + 1 WHERE keeps.id = 1;



    Update keeps
    SET (name = 'Tetons', 
    description = 'The Tetons look amazing', 
    img = 'https://cdn.britannica.com/37/145037-050-3D4B63C7/peaks-Teton-Range-Wyoming.jpg')
   
    Where id = 1



Select 
    vaults.*,
    accounts.*
    FROM vaults
    JOIN accounts ON accounts.id = vaults.creatorId
    WHERE vaults.id = 1;


    SElECT 
    vaults.*,
    accounts.*
    FROM vaults
    JOIN accounts ON accounts.id = vaults.creatorId 
    where vaults.creatorId = '66f32093b4e1c932f63ed63a';

    INSERT INTO 
    vaultKeeps(vaultId, keepId, creatorId)
    Values(2, 3, '66f32093b4e1c932f63ed63a');
    SELECT * FROM vaultKeeps 
    WHERE 
      id = LAST_INSERT_ID();


      SELECT
    vaultKeeps.*,
    keeps.*,
    accounts.*
    FROM vaultKeeps
    JOIN keeps ON keeps.id = vaultKeeps.keepId
    JOIN accounts ON accounts.id = keeps.creatorId
    WHERE vaultKeeps.vaultId = 30;


SELECT
    vaults.*,
    accounts.*
    FROM vaults
    JOIN accounts ON accounts.id = vaults.creatorId
    where vaults.creatorId = '66f32093b4e1c932f63ed63a';