#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include "wsServer/include/ws.h"

ws_cli_conn_t * unity_client;

/* when a connection is made */
void onopen(ws_cli_conn_t *client)
{
    char *cli;
    cli = ws_getaddress(client);
    printf("Connection opened, addr: %s\n", cli);
}

/* when a connection is closed */
void onclose(ws_cli_conn_t *client)
{
    char *cli;
    cli = ws_getaddress(client);
    printf("Connection closed, addr: %s\n", cli);
}

/* each time a message is recieved */
void onmessage(ws_cli_conn_t *client, const unsigned char *msg, uint64_t size, int type)
{

    int cmp;
    cmp = strcmp("Unity", (char*)msg);
    
    if (cmp==0) {
	printf("we got a unity client\n");
	unity_client = client;
    }
    
    char *cli;
    cli = ws_getaddress(client);
    printf("I receive a message %s (size: %" PRId64", type: %d), from %s\n", msg, size, type, cli);

    ws_sendframe(unity_client, (char*)msg, size, type);
}

int main(void)
{
    /* Register events. */
    struct ws_events evs;
    evs.onopen    = &onopen;
    evs.onclose   = &onclose;
    evs.onmessage = &onmessage;

    /*
     * Main loop, this function never* returns.
     *
     * *If the third argument is != 0, a new thread is created
     * to handle new connections.
     */
    ws_socket(&evs, 8000, 0, 1000);

    return (0);
}


