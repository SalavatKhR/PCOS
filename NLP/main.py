from nltk.corpus import stopwords
from nltk.text import TextCollection
from nltk.tokenize import RegexpTokenizer
from pymorphy2 import MorphAnalyzer
from Text import hse_full, imcsn_full, hsmi_full

sw = stopwords.words('russian')
tokenizer = RegexpTokenizer(r'\w+')
morph = MorphAnalyzer()

def to_normal_form(text):
    text_tokens = tokenizer.tokenize(text.lower())

    remove_sw = [word for word in text_tokens if not word in sw]

    lemmatize = [morph.parse(word)[0].normal_form for word in remove_sw]

    return lemmatize


def calculate(all_words, words):
    no_dup = list(dict.fromkeys(words))
    res = [[all_words.tf_idf(word, words), word] for word in no_dup]
    return [word for word in res if word[0] > 0.01]

texts = TextCollection([hse_full, imcsn_full, hsmi_full])

a = to_normal_form(hse_full)
b = to_normal_form(imcsn_full)
c = to_normal_form(hsmi_full)

a_tf_idf = calculate(texts, a)
b_tf_idf = calculate(texts, b)
c_tf_idf = calculate(texts, c)

documents = [a_tf_idf, b_tf_idf, c_tf_idf]

def setsSimilarity(set1, set2):
    count = 0
    for s1 in set1:
        for s2 in set2:
            if s1[1] == s2[1]:
                count += 1

    return (2 * count) / (len(set1) + len(set2))


print("Сходства hse и imcsn : {0}".format(setsSimilarity(documents[0], documents[1])))
print("Сходства hse и hsmi : {0}".format(setsSimilarity(documents[0], documents[2])))
print("Сходства imcsn и hsmi : {0}".format(setsSimilarity(documents[1], documents[2])))