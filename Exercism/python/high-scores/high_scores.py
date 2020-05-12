class HighScores(object):

    def __init__(self, scores):
        self.scores = list(scores)

    def latest(self):
        return self.scores[-1]

    def personal_best(self):
        return max(list(self.scores))

    def personal_top_three(self):
        self.scores.sort()
        lastThree = self.scores[-3:]
        lastThree.sort(reverse=True)
        return lastThree
