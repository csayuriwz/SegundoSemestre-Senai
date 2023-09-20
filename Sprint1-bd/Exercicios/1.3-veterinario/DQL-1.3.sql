--DQL
--listar todos os veterin�rios (nome e CRMV) de uma cl�nica (raz�o social)
--listar todas as ra�as que come�am com a letra S
--listar todos os tipos de pet que terminam com a letra O
--listar todos os pets mostrando os nomes dos seus donos
--listar todos os atendimentos mostrando o nome do veterin�rio que atendeu, o nome, a ra�a e o tipo do pet que foi atendido, o nome do dono do pet e o nome da cl�nica onde o pet foi atendido


USE Exercicio_1_3T;

SELECT 
	Veterinario.NomeVet
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
	Atendimento.IdAtendimento AS [NUMERO ATENDIMENTO],
	Dono.Nome AS [NOME DO DONO], 
	Pet.Nome AS [NOME DO PET], 
	Pet.IdTipoPet AS ESPECIE, 
	Pet.IdRaca AS  RA�A, 
	Veterinario.NomeVet AS VETERIN�RIO
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