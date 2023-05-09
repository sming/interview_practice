class Triangle {
    final double side1;
    final double side2;
    final double side3;

    private static double TOLERANCE = 0.0000005;

    Triangle(double side1, double side2, double side3) throws TriangleException {
        if (side1 <= 0.0 || side2 <= 0.0 || side3 <= 0.0)
            throw new TriangleException();

        this.side1 = side1;
        this.side2 = side2;
        this.side3 = side3;

        if (!isTriangle())
            throw new TriangleException();
    }

    boolean isEquilateral() {
        return equal(side1, side2) && equal(side2, side3);
    }

    /**
     * has at least two sides the same length
     */
    boolean isIsosceles() {
        return equal(side1, side2) || equal(side1, side3) || equal(side2, side3);
    }

    static boolean equal(double sideA, double sideB) {
        return Math.abs(sideA - sideB) < TOLERANCE;
    }

    /**
     * the sum of the lengths of any two sides must be greater than or equal to the length of the third side
     */
    boolean isTriangle() {
        return (side1 + side2 >= side3) && (side1 + side3 >= side2) && (side2 + side3 >= side1);
    }

    boolean isScalene() {
        return !equal(side1, side2) && !equal(side1, side3) && !equal(side2, side3);
    }

}
