package cdu.edu.ua;

public class ThreadController {

    public ThreadController(int threadCount, BreakThread breakThread) {
        for (int i = 0; i < threadCount; i++) {
            new Thread(new MyTread(i, breakThread)).start();
        }
    }
}
