package cdu.edu.ua;

public class BreakThread implements Runnable {
    private final boolean[] canBreak;

    public BreakThread(int threadCount) {
        this.canBreak = new boolean[threadCount];
    }

    @Override
    public void run() {
        for (int i = 0; i < canBreak.length; i++) {
            try {
                Thread.sleep(1000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
            canBreak[i] = true;
        }
    }

    synchronized public boolean isCanBreak(int id) {
        return canBreak[id];
    }
}
