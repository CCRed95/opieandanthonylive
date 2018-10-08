export type RootState = {};

export interface SignedOut {
  kind: "signed-out";
};

export interface SignedIn {
  kind: "signed-in";
  username: string;
};

export type Auth = SignedOut | SignedIn;