[![Run in Postman](https://run.pstmn.io/button.svg)](https://app.getpostman.com/run-collection/3455394f46992df09610)

# Filiais

## Lista
curl -X GET \
  https://localhost:5001/api/Filiais \
  -H 'Postman-Token: ac93b3fb-27bf-4e7b-a220-ad0b46398d0d' \
  -H 'cache-control: no-cache'
##Consultar
curl -X GET \
  https://localhost:5001/api/Filiais/1 \
  -H 'Postman-Token: ac93b3fb-27bf-4e7b-a220-ad0b46398d0d' \
  -H 'cache-control: no-cache'

##Inserir
curl -X POST \
  https://localhost:5001/api/Filiais \
  -H 'Content-Type: application/json' \
  -H 'Postman-Token: 03b473ee-71b0-45ca-beef-b12415795553' \
  -H 'cache-control: no-cache' \
  -d '{
	nome: '\''Filial 2'\''
}'

##Atualizar
curl -X PUT \
  https://localhost:5001/api/Filiais/2 \
  -H 'Content-Type: application/json' \
  -H 'Postman-Token: 5d98a3b4-be51-4999-a717-24d1548ef6d8' \
  -H 'cache-control: no-cache' \
  -d '{
	id: 2,
	nome: '\''Filial 2 - Alterado'\''
}'

##Excluir
curl -X DELETE \
  https://localhost:5001/api/Filiais/2 \
  -H 'Content-Type: application/json' \
  -H 'Postman-Token: 25de329c-2bec-49a1-b233-9260d77583bc' \
  -H 'cache-control: no-cache'

##Produtos
##Listar
curl -X GET \
  https://localhost:5001/api/Produtos \
  -H 'Postman-Token: ac93b3fb-27bf-4e7b-a220-ad0b46398d0d' \
  -H 'cache-control: no-cache'
##Consultar
curl -X GET \
  https://localhost:5001/api/Produtos/1 \
  -H 'Postman-Token: ac93b3fb-27bf-4e7b-a220-ad0b46398d0d' \
  -H 'cache-control: no-cache'
##Inserir
curl -X POST \
  https://localhost:5001/api/Produtos \
  -H 'Content-Type: application/json' \
  -H 'Postman-Token: 576d6b00-7853-4367-9dae-d4225bbd8da9' \
  -H 'cache-control: no-cache' \
  -d '{
	"descricao": "Limão"
}'
##Atualizar
curl -X PUT \
  https://localhost:5001/api/Produtos/1 \
  -H 'Content-Type: application/json' \
  -H 'Postman-Token: 88178c13-0a77-4425-9536-f6f261f691ac' \
  -H 'cache-control: no-cache' \
  -d '{
	"descricao": "Limão"
}'
##Excluir
curl -X DELETE \
  https://localhost:5001/api/Produtos/1 \
  -H 'Postman-Token: 0c7a90ab-730e-4022-a6f9-cc676a6a1216' \
  -H 'cache-control: no-cache'

#Listar Estoques
curl -X GET \
  https://localhost:5001/api/Estoques \
  -H 'Postman-Token: 07622f9b-b210-4b84-a817-788400e4e27e' \
  -H 'cache-control: no-cache'

#Pedidos de Estoque
##Listar
curl -X GET \
  https://localhost:5001/api/PedidoEstoques \
  -H 'Postman-Token: ffe66326-f31b-4e67-83b1-941c61687bca' \
  -H 'cache-control: no-cache'
##Consultar
curl -X GET \
  https://localhost:5001/api/PedidoEstoques/1 \
  -H 'Postman-Token: 83e48c9e-db5c-403f-be43-2c95eaa7fe92' \
  -H 'cache-control: no-cache'
#Inserir Entrada
curl -X POST \
  https://localhost:5001/api/PedidoEstoques \
  -H 'Content-Type: application/json' \
  -H 'Postman-Token: 4e39d327-369a-44e2-90fb-a1688ccf1969' \
  -H 'cache-control: no-cache' \
  -d '{
	data: "2019-03-30",
	filialId: 1,
	tipo: 0,
	itemPedidoEstoques: [
		{produtoId: 1, quantidade: 5},
		{produtoId: 2, quantidade: 3},
		{produtoId: 3, quantidade: 10},
		]
}'
##Inserir Saída
curl -X POST \
  https://localhost:5001/api/PedidoEstoques \
  -H 'Content-Type: application/json' \
  -H 'Postman-Token: 9cb879ec-fd92-4b10-af92-e6f61fb52a0a' \
  -H 'cache-control: no-cache' \
  -d '{
	data: "2019-03-30",
	filialId: 1,
	tipo: 1,
	itemPedidoEstoques: [
		{produtoId: 2, quantidade: 1},
		{produtoId: 3, quantidade: 2},
		]
}'
