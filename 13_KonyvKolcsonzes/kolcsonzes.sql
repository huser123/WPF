-- Adatbázis létrehozása
CREATE DATABASE IF NOT EXISTS KonyvKolcsonzes
CHARACTER SET utf8mb4
COLLATE utf8mb4_hungarian_ci;

-- Váltás az adatbázisra
USE KonyvKolcsonzes;

-- Vendég tábla létrehozása
CREATE TABLE IF NOT EXISTS Vendeg (
    Id INT AUTO_INCREMENT PRIMARY KEY,           -- Egyedi azonosító
    Nev VARCHAR(100) NOT NULL,                   -- Vendég neve
    Kartya VARCHAR(8) NOT NULL UNIQUE,           -- Kártyaazonosító (2 betű + 6 szám)
    Konyv VARCHAR(100) NOT NULL,                 -- Könyv címe
    Idopont DATETIME NOT NULL                    -- Kölcsönzés ideje
);

-- Tesztadatok beszúrása
INSERT INTO Vendeg (Nev, Kartya, Konyv, Idopont) VALUES
('Kovács László', 'AB123456', 'Egri csillagok', NOW() - INTERVAL 1 DAY),
('Szabó Anna', 'CD234567', 'A Pál utcai fiúk', NOW() - INTERVAL 2 DAY),
('Tóth Gábor', 'EF345678', 'Tüskevár', NOW() - INTERVAL 3 DAY),
('Nagy Eszter', 'GH456789', 'Az ember tragédiája', NOW() - INTERVAL 4 DAY),
('Fekete Dániel', 'IJ567890', 'Időfutár', NOW() - INTERVAL 5 DAY),
('Lakatos Márk', 'KL678901', 'A kőszívű ember fiai', NOW() - INTERVAL 6 DAY),
('Varga Júlia', 'MN789012', 'Harry Potter és a bölcsek köve', NOW() - INTERVAL 7 DAY),
('Horváth Petra', 'OP890123', 'A Gyűrűk Ura', NOW() - INTERVAL 8 DAY),
('Bálint Csilla', 'QR901234', 'Twilight - Alkonyat', NOW() - INTERVAL 9 DAY),
('Balogh Bence', 'ST012345', 'Sherlock Holmes kalandjai', NOW() - INTERVAL 10 DAY),
('Kis Gergely', 'UV123457', 'A da Vinci-kód', NOW() - INTERVAL 11 DAY),
('Oláh Emese', 'WX234568', 'Az alkimista', NOW() - INTERVAL 12 DAY),
('Papp Gábor', 'YZ345679', 'Éhezők viadala', NOW() - INTERVAL 13 DAY),
('Sipos Zsuzsa', 'AZ456781', 'A szent Johanna gimi', NOW() - INTERVAL 14 DAY),
('Molnár Richárd', 'BY567892', 'Rómeó és Júlia', NOW() - INTERVAL 15 DAY),
('Takács Nóra', 'CX678903', 'A tanú', NOW() - INTERVAL 16 DAY),
('Bognár Ádám', 'DV789014', 'Star Wars: Új remény', NOW() - INTERVAL 17 DAY),
('Szalai Kata', 'EW890125', 'Egy különc srác feljegyzései', NOW() - INTERVAL 18 DAY),
('Váradi Marcell', 'FU901236', 'Trónok harca', NOW() - INTERVAL 19 DAY),
('Halász Virág', 'GV012347', 'Sorstalanság', NOW() - INTERVAL 20 DAY),
('Fodor Kristóf', 'HW123458', 'Pillangó', NOW() - INTERVAL 21 DAY),
('Szűcs Kinga', 'IX234569', 'A szürke ötven árnyalata', NOW() - INTERVAL 22 DAY),
('Kerekes Levente', 'JA345670', 'A kis herceg', NOW() - INTERVAL 23 DAY),
('Bíró Emília', 'KB456781', 'A titok', NOW() - INTERVAL 24 DAY),
('Lukács Péter', 'LC567892', 'Inferno', NOW() - INTERVAL 25 DAY),
('Németh Fanni', 'MD678903', 'József Attila összes versei', NOW() - INTERVAL 26 DAY),
('Veres Milán', 'NE789014', '1984', NOW() - INTERVAL 27 DAY),
('Sárközi Borbála', 'OF890125', 'Mester és Margarita', NOW() - INTERVAL 28 DAY),
('Tímár Zoltán', 'PG901236', 'A sötét ötven árnyalata', NOW() - INTERVAL 29 DAY),
('Vass Tamás', 'QH012347', 'A katedrális', NOW() - INTERVAL 30 DAY),
('Jakab Dóra', 'RI123458', 'Az utolsó egyszarvú', NOW() - INTERVAL 31 DAY),
('Székely Márk', 'SJ234569', 'A szív könyve', NOW() - INTERVAL 32 DAY),
('Kutas Karolina', 'TK345670', 'Az arany ember', NOW() - INTERVAL 33 DAY),
('Mezei Sándor', 'UL456781', 'Gyilkosság az Orient expresszen', NOW() - INTERVAL 34 DAY),
('Antal Dorina', 'VM567892', 'Veronai szerelmesek', NOW() - INTERVAL 35 DAY),
('Tasi Roland', 'WN678903', 'A titkos kert', NOW() - INTERVAL 36 DAY),
('Czeglédi Eszter', 'XO789014', 'Ábel a rengetegben', NOW() - INTERVAL 37 DAY),
('Gáborfi Alíz', 'YP890125', 'A világ legszebb meséi', NOW() - INTERVAL 38 DAY),
('Somogyi Dávid', 'ZQ901236', 'A magyar népmesék', NOW() - INTERVAL 39 DAY),
('László Zita', 'AR012347', 'Fahrenheit 451', NOW() - INTERVAL 40 DAY),
('Juhász Lili', 'BS123458', 'Az időutazó felesége', NOW() - INTERVAL 41 DAY),
('Lovas Lóránt', 'CT234569', 'Az éhezők viadala – Futótűz', NOW() - INTERVAL 42 DAY),
('Vincze Eszter', 'DU345670', 'Fable: Árnyékvilág', NOW() - INTERVAL 43 DAY),
('Dávid Zsófi', 'EV456781', 'Az útvesztő', NOW() - INTERVAL 44 DAY),
('Lőrincz Gábor', 'FW567892', 'A homok asszonya', NOW() - INTERVAL 45 DAY),
('Fülöp Janka', 'GX678903', 'A Biblia', NOW() - INTERVAL 46 DAY),
('Barta Gergő', 'HY789014', 'Vér és méz földje', NOW() - INTERVAL 47 DAY),
('Sári Noémi', 'IZ890125', 'Káin', NOW() - INTERVAL 48 DAY),
('Kálmán Zsolt', 'JA901236', 'Az ötödik hegy', NOW() - INTERVAL 49 DAY),
('Csapó Liza', 'KB012347', 'A macska a kalapban', NOW() - INTERVAL 50 DAY);
