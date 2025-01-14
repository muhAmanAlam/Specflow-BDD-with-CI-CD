import urllib.request

opener = urllib.request.build_opener()
opener.addheaders = [('User-agent', 'Mozilla/5.0')]
urllib.request.install_opener(opener)


urllib.request.urlretrieve("https://download.zerotier.com/dist/ZeroTier%20One.msi", "one.msi")
