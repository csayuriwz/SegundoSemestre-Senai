--DQL
--listar todos os veterinários (nome e CRMV) de uma clínica (razão social)
--listar todas as raças que começam com a letra S
--listar todos os tipos de pet que terminam com a letra O
--listar todos os pets mostrando os nomes dos seus donos
--listar todos os atendimentos mostrando o nome do veterinário que atendeu, o nome, a raça e o tipo do pet que foi atendido, o nome do dono do pet e o nome da clínica onde o pet foi atendido


USE Exercicio_1_3T;

SELECT 
	Veterinario.NomeVet
FROM 
	Veterinario 
WHERE Veterinario.IdClinica = 1



SELECT 
	Raca.Descricao AS RAÇA 
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
	Pet.IdRaca AS  RAÇA, 
	Veterinario.NomeVet AS VETERINÁRIO
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