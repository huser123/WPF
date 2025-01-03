
-- Adatbázis létrehozása
CREATE DATABASE IF NOT EXISTS kirandulohely;

-- Adatbázis használata
USE kirandulohely;

-- Táblázat létrehozása
CREATE TABLE IF NOT EXISTS kirandulohelyek (
    id INT AUTO_INCREMENT PRIMARY KEY, -- Egyedi azonosító
    nev VARCHAR(100) NOT NULL,         -- Kirándulóhely neve
    helyszin VARCHAR(100) NOT NULL,    -- Régió/helyszín
    nehezsegi_szint ENUM('Könnyű', 'Közepes', 'Nehéz') NOT NULL, -- Nehézségi szint
    latogatok_szama INT NOT NULL,      -- Éves látogatószám
    tav FLOAT NOT NULL                 -- Távolság kilométerben
);

-- Példaadatok hozzáadása
INSERT INTO kirandulohelyek (nev, helyszin, nehezsegi_szint, latogatok_szama, tav) VALUES
('Lillafüred', 'Északi-Középhegység', 'Könnyű', 30000, 5.5),
('Hévízi-tó', 'Dunántúl', 'Könnyű', 45000, 3.0),
('Rám-szakadék', 'Dunakanyar', 'Közepes', 20000, 10.2),
('Börzsöny', 'Északi-Középhegység', 'Nehéz', 15000, 18.7),
('Balaton-felvidék', 'Dunántúl', 'Közepes', 25000, 12.4),
('Mátra', 'Északi-Középhegység', 'Nehéz', 12000, 20.0),
('Aggtelek', 'Északi-Középhegység', 'Könnyű', 35000, 7.5),
('Kékes', 'Északi-Középhegység', 'Közepes', 27000, 15.0),
('Tisza-tó', 'Alföld', 'Könnyű', 50000, 4.5),
('Bükki Nemzeti Park', 'Északi-Középhegység', 'Közepes', 22000, 8.3),
-- Add more entries to reach 50 rows
('Fertő-Hanság', 'Nyugat-Dunántúl', 'Könnyű', 28000, 6.0),
('Pilisszentkereszt', 'Dunakanyar', 'Közepes', 18000, 9.2),
('Hortobágy', 'Alföld', 'Könnyű', 33000, 5.0),
('Tapolcai-tavasbarlang', 'Dunántúl', 'Könnyű', 40000, 2.8),
('Őrség', 'Nyugat-Dunántúl', 'Könnyű', 25000, 5.3),
('Zemplén', 'Északi-Középhegység', 'Nehéz', 14000, 22.0),
('Badacsony', 'Dunántúl', 'Közepes', 23000, 11.4),
('Csarna-völgy', 'Dunántúl', 'Nehéz', 13000, 18.2),
('Pilis', 'Dunakanyar', 'Könnyű', 26000, 7.5),
('Duna-Ipoly Nemzeti Park', 'Dunakanyar', 'Közepes', 19000, 9.0),
('Somló-hegy', 'Dunántúl', 'Könnyű', 30000, 6.5),
('Debreceni Nagyerdő', 'Alföld', 'Könnyű', 42000, 3.5),
('Visegrád', 'Dunakanyar', 'Könnyű', 28000, 8.0),
('Zalakaros', 'Nyugat-Dunántúl', 'Könnyű', 32000, 4.0),
('Tata', 'Dunántúl', 'Könnyű', 27000, 5.2),
('Galyatető', 'Északi-Középhegység', 'Közepes', 21000, 10.0),
('Őrségi Nemzeti Park', 'Nyugat-Dunántúl', 'Könnyű', 29000, 5.7),
('Körös-Maros Nemzeti Park', 'Alföld', 'Könnyű', 31000, 6.0),
('Szilvásvárad', 'Északi-Középhegység', 'Közepes', 24000, 8.5),
('Sárospatak', 'Északi-Középhegység', 'Könnyű', 34000, 7.2),
('Mecsek', 'Dél-Dunántúl', 'Közepes', 20000, 12.3),
('Mohács', 'Dél-Dunántúl', 'Könnyű', 27000, 4.8),
('Villányi-hegység', 'Dél-Dunántúl', 'Közepes', 22000, 10.1),
('Gemenc', 'Dél-Dunántúl', 'Könnyű', 35000, 7.0),
('Ópusztaszer', 'Alföld', 'Könnyű', 38000, 6.2),
('Füzéri vár', 'Északi-Középhegység', 'Könnyű', 30000, 5.8),
('Létavértes', 'Alföld', 'Könnyű', 29000, 6.1),
('Tihany', 'Dunántúl', 'Könnyű', 41000, 4.3),
('Kis-Balaton', 'Dunántúl', 'Könnyű', 32000, 5.0),
('Cserhát', 'Északi-Középhegység', 'Nehéz', 15000, 17.6),
('Apátság', 'Dunántúl', 'Közepes', 20000, 11.9),
('Bárányos', 'Északi-Középhegység', 'Könnyű', 34000, 8.3),
('Tokaj', 'Északi-Középhegység', 'Könnyű', 36000, 6.7),
('Siófok', 'Dunántúl', 'Könnyű', 39000, 3.9),
('Pákozd', 'Dunántúl', 'Könnyű', 30000, 5.5),
('Esztergom', 'Dunakanyar', 'Közepes', 22000, 8.6),
('Szentendre', 'Dunakanyar', 'Könnyű', 35000, 6.2),
('Balatonfüred', 'Dunántúl', 'Könnyű', 41000, 4.0);
