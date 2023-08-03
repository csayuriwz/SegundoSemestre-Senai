--DQL


USE Exercicio_1_3;

SELECT 
	Veterinario.NomeVeterinario, Veterinario.CRMV
FROM 
	Veterinario 
WHERE Veterinario.IdClinica = 1



SELECT 
	Raca.Descricao AS RA�A 
FROM 
	Raca
WHERE Raca.Descricao LIKE 's%'



SELECT 
	TipoPet.Descricao AS [ESPECIE DO PET]
FROM 
	TipoPet
WHERE TipoPet.Descricao LIKE '%o'


SELECT *
FROM Pet
LEFT JOIN Dono 
	ON Dono.IDDono = pet.IdDono


SELECT 
	Atendimento.IDAtendimento AS [NUMERO ATENDIMENTO],
	Dono.NomeDono AS [NOME DO DONO], 
	Pet.NomePet AS [NOME DO PET], 
	Pet.IdTipoPet AS ESPECIE, 
	Pet.IdRaca AS  RA�A, 
	Veterinario.NomeVeterinario AS VETERIN�RIO, 
	Clinica.NomeClinica AS CL�NICA
FROM 
	Atendimento
LEFT JOIN Veterinario 
	ON Veterinario.IdVeterinario = Atendimento.IdVeterinario
LEFT JOIN Pet
	ON Pet.IdPet = Atendimento.IdPet
LEFT JOIN Dono 
	ON Dono.IdDono = Pet.IdDono
LEFT JOIN Clinica 
	ON Clinica.IdClinica = Veterinario.IdClinica;