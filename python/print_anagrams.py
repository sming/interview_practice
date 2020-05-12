from typing import List, OrderedDict
from collections import defaultdict

'''
 Say you are given the strings:
 abc
 cba
 abbc
 fog
 gof

 we want to print out the anagrams together:
 abc, cba
 abbc,
 fog, gof
'''

class AnagramPrinter:
    _words: List[str]
    _output: List[List[str]]
    def __init__(self, words: List[str]):
        self._words = words

    def print(self):
        listOfLists: List[List[str]] = self._order_by_anagram()

        for words in listOfLists:
            print(",".join(words))


    def _order_by_anagram(self) -> List[List[str]]:
        result: OrderedDict[str, List[str]] = defaultdict(list)

        for word in self._words:
            key = ''.join(sorted(word))
            if key not in result:
                result[key] = list()

            result[key].append(word)

        return list([result[x] for x in result.keys()])

if __name__== "__main__":
    a = AnagramPrinter(["abc", "cba", "abbc", "fog", "gof"])
    a.print()
