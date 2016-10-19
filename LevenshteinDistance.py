# Calculate how close words are

def LevenshteinDistance(string_a, string_b):
    if min([len(string_a), len(string_b)]):
        return min([
            LevenshteinDistance(string_a[:-1], string_b) + 1,
            LevenshteinDistance(string_a, string_b[:-1]) + 1,
            LevenshteinDistance(string_a[:-1], string_b[:-1]) + int(string_a[-1] != string_b[-1])
        ])
    else:
        return max([len(string_a), len(string_b)])

    
def LevenshteinDistanceForward(string_a, string_b):
    if min([len(string_a), len(string_b)]):
        return min([
            LevenshteinDistance(string_a[0:], string_b) + 1,
            LevenshteinDistance(string_a, string_b[0:]) + 1,
            LevenshteinDistance(string_a[0:], string_b[0:]) + int(string_a[0] != string_b[0])
        ])
    else:
        return max([len(string_a), len(string_b)])

    
class DictionaryReadOnly:
    
    def __init__(self,words):
        self.words = words
        self.history = {}

    def find_most_similar(self,term):
        if term in self.words:
            return term
        elif term not in self.history:
            smallest = len(term)
            closest = None
            for word in self.words:
                print(word)
                distance = LevenshteinDistance(term, word)
                if smallest > distance:
                    closest = word
                    smallest = distance
            
            self.history[term] = closest
            return closest
        else:
            return self.common[term]


# some test cases:

Dictionary = DictionaryRW


words=['cherry', 'peach', 'pineapple', 'melon', 'strawberry', 'raspberry', 'apple', 'coconut', 'banana']
test_dict=Dictionary(words)
assert (test_dict.find_most_similar('strawbery') == 'strawberry')
assert (test_dict.find_most_similar('berry') == 'cherry')
assert (test_dict.find_most_similar('aple') == 'apple')
