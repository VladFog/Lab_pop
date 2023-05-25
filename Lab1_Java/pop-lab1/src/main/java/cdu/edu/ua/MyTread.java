package cdu.edu.ua;

public class MyTread implements Runnable {
    private final int id;
    private final BreakThread breakThread;

    public MyTread(int id, BreakThread breakThread) {
        this.id = id;
        this.breakThread = breakThread;
    }

    @Override
    public void run() {
        long sum = 0;
        long additions = 0;
        do {
            sum++;
            additions++;
        } while (!breakThread.isCanBreak(id));
        System.out.println(id + " - " + sum + ", additions: " + additions + ';');
    }
}
