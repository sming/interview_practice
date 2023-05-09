/**
 *    |
 *    |
 *    |
 * 0,0 - - - - - -
 * x →
 * y ↑
 */
public class Robot {
    private int x;
    private int y;
    private GridPosition pos;
    private Orientation facing;

    public Robot(GridPosition pos, Orientation facing) {
        this.x = pos.x;
        this.y = pos.y;
        this.facing = facing;
    }

    public Robot turnRight() {
        this.facing = Orientator.turnRight(this.facing);
        return this;
    }

    public Robot turnLeft() {
        this.facing = Orientator.turnLeft(this.facing);
        return this;
    }

    public Robot advance() {
        switch (facing) {
            case NORTH:
                y++;
                break;
            case SOUTH:
                y--;
                break;
            case EAST:
                x++;
                break;
            case WEST:
                x--;
                break;
            default:
                throw new RuntimeException("Programming error");
        }

        return this;
    }

    public Robot simulate(String instructions) {
        Commander.command(this, instructions);
        return this;
    }

    public Orientation getOrientation() { return facing; }
    public GridPosition getGridPosition() { return new GridPosition(x, y); }

    private static class Commander {
        static Robot command(Robot r, String command) {
            for (int i = 0; i < command.length(); i++) {
                char c = command.charAt(i);
                switch (c) {
                    case 'A':
                        r.advance();
                        break;
                    case 'R':
                        r.turnRight();
                        break;
                    case 'L':
                        r.turnLeft();
                        break;
                    default:
                        throw new RuntimeException("Invalid command");
                }
            }
            return r;
        }
    }

    private static class Orientator {
        static Orientation turnRight(Orientation ori) {
            int oriVal = ori.ordinal();
            return Orientation.values()[(oriVal + 1) % 4];
        }

        static Orientation turnLeft(Orientation ori) {
            int oriVal = ori.ordinal();
            if (oriVal == 0)
                return Orientation.WEST;
            else
                return Orientation.values()[(oriVal - 1)];
        }
    }
}