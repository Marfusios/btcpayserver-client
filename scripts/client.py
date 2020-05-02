from btcpay import BTCPayClient
import pickle

#client = BTCPayClient.create_client(host='https://btcpay.adsearches.net', code='mcdzF57')
#pickle.dump( client, open( "client.p", "wb" ) )
#print(client)

client2 = pickle.load( open( "client.p", "rb" ) )
rates = client2.get_rates()
print(rates)


# https://btcpay.adsearches.net/
# juUR1pL