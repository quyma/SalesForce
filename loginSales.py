import requests 
import json

#Defini parametros do Body
payload = {'clientId': '3MVG9PbQtiUzNgN5HOnTahCd6GQoISPUlE2xX6NhFUjAdoTsZZDVxfnXQN84t_htve2l4Zj.6cBFHY_9ARGFB', 'clientSecret': '12779F752C4743C42A9F44BE1D76B20CC9C70CEAB98C2347E79978421E74F3A8'}

# Defini Url e requisição
r = requests.post('https://uat-itau-unibanco-operacoeseprodutos.cs51.force.com/services/apexrest/services/oauth2/token',data=payload)
returncode = r.status_code;
body = r.text;

# função para deserializar o json
class Payload(object):
    def __init__(self, j):
        self.__dict__ = json.loads(j) 

# Body
p = Payload(body)

instance_url = p.instance_url
access_token = p.access_token

#        -----------------------       #
#Defini parametros do Body
authorization = 'Bearer ' + access_token
payload = {'Authorization2': authorization}

# Chamando Api Tooling da Salesforce
url = instance_url + '/services/data/v50.0/tooling/query?q=SELECT+MetadataComponentName,MetadataComponentType+FROM+MetadataComponentDependency'
print(url)
r = requests.get(url,data=payload)
 

#returncode = r.status_code;
body = r.text;
print(body)



print('Return code:' , url)











