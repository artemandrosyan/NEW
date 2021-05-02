import { customAlphabet } from 'nanoid';
class RemoteBuilderUniqueID {
  static alphabet = '0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz';
  static GetUniqueId(length): string {
    return customAlphabet(RemoteBuilderUniqueID.alphabet, length)();
  }
}
export default RemoteBuilderUniqueID;
