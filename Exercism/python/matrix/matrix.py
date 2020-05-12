class Matrix(object):
    def __init__(self, matrix_string):
        numRows = matrix_string.count("\n") + 1
        spacesOnlyStr = matrix_string.replace('\n', ' ')
        singleList = spacesOnlyStr.split()
        numCols = int(len(singleList) / numRows)    # in prod code, would guard for div 0

        self.rows = []
        row = []
        for i, number in enumerate(singleList):
            row.append(int(number))

            if (i + 1) % numCols == 0:
                self.rows.append(row)
                row = []

        self.cols = [None] * numCols
        for i in range(numCols):
            self.cols[i] = []
            for row in self.rows:
                self.cols[i].append(row[i])
                
    def row(self, index):   # returns list of numbers in that row
        return self.rows[index - 1]

    def column(self, index):    # returns list of numbers in that column
        return self.cols[index - 1]
