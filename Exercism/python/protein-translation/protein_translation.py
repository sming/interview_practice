def proteins(strand):

    condonToAcidMap = {
        'AUG':'Methionine',
        'UUU':'Phenylalanine',
        'UUC':'Phenylalanine',
        'UUA':'Leucine',
        'UUG':'Leucine',
        'UCU':'Serine',
        'UCC':'Serine',
        'UCA':'Serine',
        'UCG':'Serine',
        'UAU':'Tyrosine',
        'UAC':'Tyrosine',
        'UGU':'Cysteine',
        'UGC':'Cysteine',
        'UGG':'Tryptophan',
        'UAA':'STOP',
        'UAG':'STOP',
        'UGA':'STOP',        
    }

    CONDON_LEN = 3
    STOP_WORD = 'STOP'
    acidList = []
    acidStr = ''
    
    for i, c in enumerate(strand):
        acidStr = acidStr + c
        
        if i > 0 and (i + 1) % CONDON_LEN == 0:
            if acidStr in condonToAcidMap:
                if condonToAcidMap[acidStr] == STOP_WORD:
                        break
                else:
                    acidList.append(condonToAcidMap[acidStr])
            else:
                raise ValueError()

            acidStr = ''
    
    return acidList