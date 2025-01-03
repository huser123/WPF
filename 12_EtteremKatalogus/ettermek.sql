-- ettermek.sql
-- Az adatbázis inicializálása és mintaadatok feltöltése

-- Adatbázis létrehozása
CREATE DATABASE IF NOT EXISTS ettermek;

-- Adatbázis használata

USE ettermek;

-- Éttermek táblájának létrehozása
CREATE TABLE ettermek (
    id INT AUTO_INCREMENT PRIMARY KEY, -- Egyedi azonosító minden étteremhez
    nev VARCHAR(100) NOT NULL,         -- Az étterem neve
    varos VARCHAR(50) NOT NULL,       -- Az étterem elhelyezkedése (város)
    cim VARCHAR(150),                 -- Az étterem pontos címe
    arkategoriak ENUM('Alacsony', 'Kozepes', 'Magas') NOT NULL -- Az árkategória
);

-- Mintaadatok feltöltése
INSERT INTO ettermek (nev, varos, cim, arkategoriak) VALUES
('Pizza Paradicsom', 'Budapest', 'Fő utca 1.', 'Kozepes'),
('Gulyás Étterem', 'Debrecen', 'Kossuth tér 2.', 'Alacsony'),
('Hamburger Ház', 'Szeged', 'Tisza-parti sétány 5.', 'Kozepes'),
('Édes Élet', 'Győr', 'Arany János utca 10.', 'Magas'),
('Fish & Chips', 'Budapest', 'Margit körút 14.', 'Kozepes'),
('Sushi Bár', 'Debrecen', 'Csapó utca 8.', 'Magas'),
('Magyaros Tányér', 'Pécs', 'Széchenyi tér 20.', 'Alacsony'),
('Vega Vendéglő', 'Sopron', 'Deák tér 3.', 'Kozepes'),
('Steakhouse', 'Miskolc', 'Petőfi utca 15.', 'Magas'),
('Cukorvár', 'Budapest', 'Szabadság tér 1.', 'Kozepes'),
('Friss Falatok', 'Nyíregyháza', 'Bocskai utca 12.', 'Alacsony'),
('Pizza King', 'Eger', 'Dobó tér 4.', 'Kozepes'),
('Kertvárosi Konyha', 'Tatabánya', 'Dózsa György út 3.', 'Magas'),
('Halászlé Ház', 'Szeged', 'Horgász utca 5.', 'Alacsony'),
('Gombóc Világ', 'Székesfehérvár', 'Koronázó tér 7.', 'Kozepes'),
('Tészta Mánia', 'Kecskemét', 'Katona József tér 8.', 'Kozepes'),
('Ételkert', 'Veszprém', 'Jókai utca 2.', 'Magas'),
('Gasztro Udvar', 'Zalaegerszeg', 'Kossuth utca 6.', 'Kozepes'),
('Falusi Vendégház', 'Kaposvár', 'Ady Endre utca 10.', 'Alacsony'),
('Mediterrán Ízek', 'Szentendre', 'Duna korzó 3.', 'Magas'),
('Sós és Édes', 'Győr', 'Városház tér 9.', 'Kozepes'),
('Grill Sarok', 'Siófok', 'Fő utca 11.', 'Alacsony'),
('Kóstoló Konyha', 'Esztergom', 'Kossuth Lajos utca 4.', 'Kozepes'),
('Nemzeti Tányér', 'Balatonfüred', 'Tagore sétány 2.', 'Magas'),
('Frissensült Büfé', 'Mosonmagyaróvár', 'Árpád utca 5.', 'Alacsony'),
('Lángos Birodalom', 'Hévíz', 'Rákóczi utca 12.', 'Kozepes'),
('Svájci Szelet', 'Kőszeg', 'Jurisics tér 8.', 'Magas'),
('Vadétel Vendéglő', 'Zirc', 'Rákóczi utca 10.', 'Kozepes'),
('Sörkert', 'Békéscsaba', 'Gyulai út 15.', 'Alacsony'),
('Palacsinta Palota', 'Salgótarján', 'Rákóczi út 6.', 'Kozepes'),
('Kávéház Klasszik', 'Budaörs', 'Szabadság út 5.', 'Magas'),
('Magyaros Ízek', 'Komárom', 'Bem utca 7.', 'Kozepes'),
('Pizza Pavilon', 'Vác', 'Széchenyi utca 9.', 'Alacsony'),
('Kerthelyiség', 'Gödöllő', 'Dózsa György út 8.', 'Kozepes'),
('Nemzeti Büfé', 'Tatán', 'Fő tér 10.', 'Magas'),
('Főzelék Bár', 'Eger', 'Kis Dobó tér 3.', 'Kozepes'),
('Borkóstoló', 'Pápa', 'Fő utca 15.', 'Magas'),
('Városi Gyorsétterem', 'Kazincbarcika', 'Mátyás király út 2.', 'Kozepes'),
('Halászbástya Étterem', 'Esztergom', 'Bazilika tér 1.', 'Magas'),
('Zöld Liget', 'Szekszárd', 'Bajcsy-Zsilinszky utca 4.', 'Alacsony'),
('Tenger Gyümölcsei', 'Balatonalmádi', 'Kikötő tér 6.', 'Magas'),
('Szendvics Expressz', 'Hódmezővásárhely', 'Kossuth utca 8.', 'Kozepes'),
('Francia Sarok', 'Keszthely', 'Fő tér 7.', 'Magas'),
('Fűszeres Ételek', 'Békéscsaba', 'Kazinczy utca 9.', 'Alacsony'),
('Piknik Pihenő', 'Gyula', 'Almásy tér 11.', 'Kozepes'),
('Kávéház Kuckó', 'Pécs', 'Rákóczi utca 14.', 'Kozepes'),
('Itália Kincsei', 'Szombathely', 'Király utca 5.', 'Magas');
