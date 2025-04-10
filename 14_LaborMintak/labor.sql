-- Adatbázis létrehozása
CREATE DATABASE IF NOT EXISTS LaborMintak
CHARACTER SET utf8mb4
COLLATE utf8mb4_hungarian_ci;

USE LaborMintak;

-- Tábla létrehozása
CREATE TABLE IF NOT EXISTS Minta (
    Id INT AUTO_INCREMENT PRIMARY KEY,                -- Egyedi azonosító
    Kod VARCHAR(8) NOT NULL UNIQUE,                   -- Egyedi mintaazonosító (formátum: 123AB456)
    Nev VARCHAR(100) NOT NULL,                        -- Beteg neve
    Tipus VARCHAR(100) NOT NULL,                      -- Minta típusa (pl. vér, vizelet stb.)
    Erkezes DATETIME NOT NULL                         -- Minta beérkezési időpontja
);

-- 50 példa-adat beszúrása
INSERT INTO Minta (Kod, Nev, Tipus, Erkezes) VALUES
('123AB456', 'Kiss Gábor', 'Vér', NOW() - INTERVAL 1 DAY),
('234BC567', 'Tóth Eszter', 'Vizelet', NOW() - INTERVAL 2 DAY),
('345CD678', 'Nagy László', 'Szövet', NOW() - INTERVAL 3 DAY),
('456DE789', 'Szabó Ágnes', 'Nyál', NOW() - INTERVAL 4 DAY),
('567EF890', 'Balogh Péter', 'Széklet', NOW() - INTERVAL 5 DAY),
('678FG901', 'Oláh Kata', 'Vér', NOW() - INTERVAL 6 DAY),
('789GH012', 'Molnár Imre', 'Vizelet', NOW() - INTERVAL 7 DAY),
('890HI123', 'Varga Erika', 'Szövet', NOW() - INTERVAL 8 DAY),
('901IJ234', 'Kovács Zoltán', 'Vér', NOW() - INTERVAL 9 DAY),
('012JK345', 'Fekete Júlia', 'Vér', NOW() - INTERVAL 10 DAY),
('111LM456', 'Papp Attila', 'Vér', NOW() - INTERVAL 11 DAY),
('222MN567', 'Barta Noémi', 'Szövet', NOW() - INTERVAL 12 DAY),
('333NO678', 'Horváth Tamás', 'Vizelet', NOW() - INTERVAL 13 DAY),
('444OP789', 'Lakatos Fanni', 'Széklet', NOW() - INTERVAL 14 DAY),
('555PQ890', 'Bognár Márton', 'Vér', NOW() - INTERVAL 15 DAY),
('666QR901', 'Kerekes Nóra', 'Vér', NOW() - INTERVAL 16 DAY),
('777RS012', 'Sipos Gergely', 'Vér', NOW() - INTERVAL 17 DAY),
('888ST123', 'Antal Zsófia', 'Szövet', NOW() - INTERVAL 18 DAY),
('999TU234', 'Somogyi Dániel', 'Nyál', NOW() - INTERVAL 19 DAY),
('000UV345', 'Sánta Kinga', 'Vér', NOW() - INTERVAL 20 DAY),
('111VW456', 'Veres Áron', 'Vizelet', NOW() - INTERVAL 21 DAY),
('222WX567', 'Dávid Boglárka', 'Széklet', NOW() - INTERVAL 22 DAY),
('333XY678', 'Juhász Ákos', 'Vér', NOW() - INTERVAL 23 DAY),
('444YZ789', 'Szalai Tamara', 'Szövet', NOW() - INTERVAL 24 DAY),
('555ZA890', 'Tímár Balázs', 'Vér', NOW() - INTERVAL 25 DAY),
('666AB901', 'Gábor Lili', 'Vizelet', NOW() - INTERVAL 26 DAY),
('777BC012', 'Tasi Roland', 'Vér', NOW() - INTERVAL 27 DAY),
('888CD123', 'Bíró Dorina', 'Széklet', NOW() - INTERVAL 28 DAY),
('999DE234', 'Mezei András', 'Vér', NOW() - INTERVAL 29 DAY),
('000EF345', 'Czeglédi Laura', 'Nyál', NOW() - INTERVAL 30 DAY),
('123FG456', 'Lovas Viktória', 'Szövet', NOW() - INTERVAL 31 DAY),
('234GH567', 'Sárközi Ádám', 'Vér', NOW() - INTERVAL 32 DAY),
('345HI678', 'Halász Fruzsina', 'Vizelet', NOW() - INTERVAL 33 DAY),
('456IJ789', 'Vass Zsombor', 'Széklet', NOW() - INTERVAL 34 DAY),
('567JK890', 'Török Veronika', 'Vér', NOW() - INTERVAL 35 DAY),
('678KL901', 'Kutas Péter', 'Nyál', NOW() - INTERVAL 36 DAY),
('789LM012', 'Molnár Zita', 'Szövet', NOW() - INTERVAL 37 DAY),
('890MN123', 'Antal Dóra', 'Vér', NOW() - INTERVAL 38 DAY),
('901NO234', 'Pintér Soma', 'Vizelet', NOW() - INTERVAL 39 DAY),
('012OP345', 'Gál Petra', 'Széklet', NOW() - INTERVAL 40 DAY),
('111PQ456', 'Fodor Vince', 'Nyál', NOW() - INTERVAL 41 DAY),
('222QR567', 'Takács Emma', 'Vér', NOW() - INTERVAL 42 DAY),
('333RS678', 'Lukács Ádám', 'Szövet', NOW() - INTERVAL 43 DAY),
('444ST789', 'Váradi Lilla', 'Vizelet', NOW() - INTERVAL 44 DAY),
('555TU890', 'Oláh Zsolt', 'Vér', NOW() - INTERVAL 45 DAY),
('666UV901', 'Papp Nikolett', 'Nyál', NOW() - INTERVAL 46 DAY),
('777VW012', 'Németh Viktor', 'Széklet', NOW() - INTERVAL 47 DAY),
('888WX123', 'Rácz Csenge', 'Vér', NOW() - INTERVAL 48 DAY),
('999XY234', 'Kiss Tamás', 'Szövet', NOW() - INTERVAL 49 DAY),
('000YZ345', 'Major Krisztina', 'Vér', NOW() - INTERVAL 50 DAY);
