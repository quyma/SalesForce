import json
from simple_salesforce import Salesforce, SalesforceLogin, SFType

# inicia sessão com a org da salesforce, right?
loginInfo = json.load(open('login.json'))
username = loginInfo['username']
password = loginInfo['password']
security_token = loginInfo['security_token']
domain = 'login'

#login de sessão
sf = Salesforce(username=username, password=password, security_token=security_token, domain=domain)
#sf = Salesforce(username='myemail@example.com', password='password', security_token='token')
 
